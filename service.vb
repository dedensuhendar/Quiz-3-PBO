Public Class service
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable

    Dim strsql As String
    Dim info As String
    Private _idservice As System.Int32
    Private _kode_service As System.String
    Private _jenis_service As System.String
    Private _harga As System.Int32
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_service()
        Get
            Return _kode_service
        End Get
        Set(ByVal value)
            _kode_service = value
        End Set
    End Property
    Public Property jenis_service()
        Get
            Return _jenis_service
        End Get
        Set(ByVal value)
            _jenis_service = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (service_baru = True) Then
            strsql = "Insert into service(kode_service,jenis_service,harga) values ('" & _kode_service & "','" & _jenis_service & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update service set kode_service='" & _kode_service & "', jenis_service='" & _jenis_service & "', harga='" & _harga & "' where kode_service='" & _kode_service & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Cariservice(ByVal skode_service As String)
        DBConnect()
        strsql = "SELECT * FROM service WHERE kode_service='" & skode_service & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            service_baru = False
            DR.Read()
            kode_service = Convert.ToString((DR("kode_service")))
            jenis_service = Convert.ToString((DR("jenis_service")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            service_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_service As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM service WHERE kode_service='" & skode_service & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM service"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
