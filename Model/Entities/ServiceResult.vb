Imports System.Runtime.Serialization

<DataContract>
Public Class ServiceResult
    <DataMember>
    Public Result As Boolean

    <DataMember>
    Public Message As String

    <DataMember>
    Public Ret As String

    Public Sub New()
    End Sub

    Public Sub New(bResult As Boolean, sMessage As String, sReturn As String)
        Result = bResult
        Message = sMessage
        Ret = sReturn
    End Sub
End Class
