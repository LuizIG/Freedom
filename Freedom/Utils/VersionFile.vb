Imports System.IO
Imports System.Web.Hosting

Public Class VersionFile
    Public Shared Function Check(rutaRelativa As String) As String
        If HttpRuntime.Cache(rutaRelativa) Is Nothing Then
            Dim rutaAbsoluta As String = HostingEnvironment.MapPath(Convert.ToString("~") & rutaRelativa)
            If rutaAbsoluta Is Nothing Then
                Return TryCast(HttpRuntime.Cache(rutaRelativa), String)
            End If
            Dim fecha = File.GetLastWriteTime(rutaAbsoluta).ToString("yyyyMMddmm")
            Dim index As Integer = rutaRelativa.Length
            Dim vers As String = rutaRelativa.Insert(index, "?v=" + fecha)
            HttpRuntime.Cache.Insert(rutaRelativa, vers, New CacheDependency(rutaAbsoluta))
        End If

        Return TryCast(HttpRuntime.Cache(rutaRelativa), String)
    End Function
End Class
