using Models;
using Repository;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controllers {

    public class Middleware : IMiddleware
        {   

        public static List<Models.Usuario> BuscaUsuarioAdministrador()
        {
            try
            {
                using (Context context = new Context())
                {
                    IQueryable<Models.Perfil> perfisAdmin = context.Perfis.Where(p => p.Admnistrador);
                    if (perfisAdmin != null)
                    {
                        List<Models.Usuario> usuariosAdmin = (from u in context.Usuarios where perfisAdmin.Any(p => p.Usuario_id == u.Id)select u).ToList();
                        return usuariosAdmin;
                    }
                return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Models.Sessao> BuscaUsuarioLogado()
        {
            try
            {
                using (Context context = new Context())
                {
                    IQueryable<Models.Sessao> sessoes = context.Sessoes.Where(s => s.Id != 0);
                    if (sessoes != null)
                    {
                        List<Models.Sessao> usuariosLogados = (from u in context.Sessoes where sessoes.Any(s => s.Usuario_id == u.Usuario_id)select u).ToList();
                        return usuariosLogados;
                    }
                return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Models.Usuario> BuscaUsuarioNormal()
        {
            try
            {
                using (Context context = new Context())
                {
                    IQueryable<Models.Perfil> perfisAdmin = context.Perfis.Where(p => p.Admnistrador == false);
                    if (perfisAdmin != null)
                    {
                        List<Models.Usuario> usuariosAdmin = (from u in context.Usuarios where perfisAdmin.Any(p => p.Usuario_id == u.Id)select u).ToList();
                        return usuariosAdmin;
                    }
                return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}


