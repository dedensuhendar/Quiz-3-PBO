Public Class connection
    Private _datasource As String
    Private _database As String
    Private _datareader As System.Data.SqlClient.SqlDataReader
    Private _found As Boolean = False
    Private _connected As Boolean = False

    ''' <summary>
    ''' Penampung data hasil pencarian fungsi searchone
    ''' </summary>
    Public Property DataReader() As Object
        Get
            Return _datareader
        End Get
        Set(ByVal value As Object)
            _datareader = value
        End Set
    End Property

    ''' <summary>
    ''' Nama Data Source SQL Server Express, default = NamaPC\SQLEXPRESS
    ''' </summary>
    Public Property DataSource() As String
        Get
            Return _datasource
        End Get
        Set(ByVal value As String)
            _datasource = value
        End Set
    End Property


    ''' <summary>
    ''' Nama Database di SQL Server Express
    ''' </summary>
    Public Property DatabaseName() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property

    ''' <summary>
    ''' Hasil pencarian data (True = Ditemukan, False=Tdk ditemukan)
    ''' </summary>
    Public Property RecordFound() As Boolean
        Get
            Return _found
        End Get
        Set(ByVal value As Boolean)
            _found = value
        End Set
    End Property

    ''' <summary>
    ''' Proses menyambungkan koneksi (SQL Server Express with Integrated Security = True without Username or Password)
    ''' </summary>
    Public Sub Connect()
        Try
            conn.Close()
            conn.ConnectionString = "Data Source=" & _datasource & ";Initial Catalog=" & _database & ";Integrated Security=True"

            conn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (conn.State = True) Then
                _connected = True
            Else
                _connected = False
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Proses memutuskan koneksi
    ''' </summary>
    Public Sub Disconnect()
        If (conn.State = True) Then
            conn.Close()
            conn.Dispose()
            _connected = False
        End If
    End Sub
End Class
