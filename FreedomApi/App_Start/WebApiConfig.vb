Imports System.Net.Http
Imports System.Web.Http
Imports FreedomApi.Areas.HelpPage
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
        ' Configuración y servicios de Web API
        ' Configure Web API para usar solo la autenticación de token de portador.
        config.SuppressDefaultHostAuthentication()
        config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))
        config.SetDocumentationProvider(New XmlDocumentationProvider(HttpContext.Current.Server.MapPath("bin/FreedomApi.xml")))
        ' Rutas de Web API
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute(
          name:="DefaultApi",
          routeTemplate:="api/{controller}/{id}",
          defaults:=New With {.id = RouteParameter.Optional}
      )
    End Sub
End Module
