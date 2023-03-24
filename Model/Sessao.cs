using System;
using System.Linq;
using Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Sessao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }

        public Sessao() {

        }

        public Sessao(int usuarioId)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            this.UsuarioId = usuarioId;
            this.Token = token;
            this.DataCriacao = DateTime.UtcNow;
            this.DataExpiracao = DateTime.UtcNow + TimeSpan.FromDays(1);

            Database db = new Database();
            db.Sessoes.Add(this);
            db.SaveChanges();

            this.Usuario = Usuario.BuscarUsuario(usuarioId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj == this) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            Sessao sessao = (Sessao) obj;
            return this.Id == sessao.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            bool ativa = this.DataExpiracao > DateTime.UtcNow;
            // byte[] data = Convert.FromBase64String(this.Token);
            // DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            // if (when < DateTime.UtcNow.AddHours(-24)) {
            // // too old
            // }
            return $"Id: {this.Id}, Usuario: {this.Usuario.Nome}, Token: {this.Token}, DataCriacao: {this.DataCriacao}, DataExpiracao: {this.DataExpiracao}, Ativa: {(ativa ? "Sim" : "Não")}";
        }

        public static Sessao AlterarSessao(int id, DateTime dataExpiracao)
        {
            Database db = new Database();
            try
            {
                Sessao sessao = (from s in db.Sessoes
                                 where s.Id == id
                                 select s).First();
                sessao.DataExpiracao = dataExpiracao;
                db.SaveChanges();
                return sessao;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Sessao> ListarSessoes()
        {
            Database db = new Database();
            try
            {
                List<Sessao> sessoes = db.Sessoes.Include("Usuario").ToList();
                return sessoes;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }   
}