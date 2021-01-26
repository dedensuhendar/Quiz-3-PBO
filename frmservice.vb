Public Class frmservice

    Private Sub reload()
        Oservice.getAllData(DataGridView1)
    End Sub

    Private Sub frmservice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub

    Private Sub Tampilservice()
        txtkodeservice.Text = Oservice.kode_service
        txtjenisservice.Text = Oservice.jenis_service
        txtharga.Text = Oservice.harga
    End Sub
    Private Sub SimpanDataService()
        Oservice.kode_service = txtkodeservice.Text
        Oservice.jenis_service = txtjenisservice.Text
        Oservice.harga = txtharga.Text
        Oservice.Simpan()
        reload()
        If (Oservice.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (Oservice.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        ClearEntry()
    End Sub
    Private Sub clearentry()
        txtkodeservice.Clear()
        txtjenisservice.Clear()
        txtharga.Clear()
        txtkodeservice.Focus()
        txtbayar.Clear()
        txtkembalian.Clear()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If (txtkodeservice.Text <> "" And txtjenisservice.Text <> "") Then
            SimpanDataService()
            clearentry()
            reload()
        Else
            MessageBox.Show("Kode tidak boleh kosong!")
        End If
    End Sub

    Private Sub txtkodeservice_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtkodeservice.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Oservice.Cariservice(txtkodeservice.Text)
            If (Service_baru = False) Then
                Tampilservice()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub txtkodeservice_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtkodeservice.TextChanged

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        clearentry()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        txtkembalian.Text = CDec(txtbayar.Text) - CDec(txtharga.Text)
    End Sub
End Class