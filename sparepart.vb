Public Class sparepart
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable

    Dim strsql As String
    Dim info As String
    Private _idsparepart As System.Int32
    Private _kode_sparepart As System.String
    Private _nama_sparepart As System.String
    Private _harga As System.Int32
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_sparepart()
        Get
            Return _kode_sparepart
        End Get
        Set(ByVal value)
            _kode_sparepart = value
        End Set
    End Property
    Public Property nama_sparepart()
        Get
            Return _nama_sparepart
        End Get
        Set(ByVal value)
            _nama_sparepart = value
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
        If (sparepart_baru = True) Then
            strsql = "Insert into sparepart(kode_sparepart,nama_sparepart,harga) values ('" & _kode_sparepart & "','" & _nama_sparepart & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update sparepart set kode_sparepart='" & _kode_sparepart & "', nama_sparepart='" & _nama_sparepart & "', harga='" & _harga & "' where kode_sparepart='" & _kode_sparepart & "'"
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
    Public Sub Carisparepart(ByVal skode_sparepart As String)
        DBConnect()
        strsql = "SELECT * FROM sparepart WHERE kode_sparepart='" & skode_sparepart & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            sparepart_baru = False
            DR.Read()
            kode_sparepart = Convert.ToString((DR("kode_sparepart")))
            nama_sparepart = Convert.ToString((DR("nama_sparepart")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            sparepart_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_sparepart As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM sparepart WHERE kode_sparepart='" & skode_sparepart & "'"
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
            strsql = "SELECT * FROM sparepart"
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
