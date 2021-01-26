Public Class frmsparepart

    Private Sub reload()
        OSparepart.getAllData(DataGridView1)
    End Sub


    Private Sub frmsparepart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub

    Private Sub Tampilsparepart()
        txtkodesparepart.Text = OSparepart.kode_sparepart
        txtnamasparepart.Text = OSparepart.nama_sparepart
        txthargasparepart.Text = OSparepart.harga
    End Sub
    Private Sub SimpanDataSparepart()
        OSparepart.kode_sparepart = txtkodesparepart.Text
        OSparepart.nama_sparepart = txtnamasparepart.Text
        OSparepart.harga = txthargasparepart.Text
        OSparepart.Simpan()
        reload()
        If (OSparepart.InsertState = True) Then
            MessageBox.Show("Data berhasil disimpan.")
        ElseIf (OSparepart.UpdateState = True) Then
            MessageBox.Show("Data berhasil diperbarui.")
        Else
            MessageBox.Show("Data gagal disimpan.")
        End If
        clearentry()
    End Sub

    Private Sub clearentry()
        txtkodesparepart.Clear()
        txtnamasparepart.Clear()
        txthargasparepart.Clear()
        txtkodesparepart.Focus()
        txtbayarsparepart.Clear()
        txtkembaliansparepart.Clear()
    End Sub

    Private Sub txtkodesparepart_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtkodesparepart.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            OSparepart.Carisparepart(txtkodesparepart.Text)
            If (sparepart_baru = False) Then
                Tampilsparepart()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnclearsparepart.Click
        clearentry()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnbayarsparepart.Click
        txtkembaliansparepart.Text = CDec(txtbayarsparepart.Text) - CDec(txthargasparepart.Text)
    End Sub

    Private Sub btnsavesparepart_Click(sender As System.Object, e As System.EventArgs) Handles btnsavesparepart.Click
        If (txtkodesparepart.Text <> "" And txtnamasparepart.Text <> "") Then
            SimpanDataSparepart()
            clearentry()
            reload()
        Else
            MessageBox.Show("Kode tidak boleh kosong!")
        End If
    End Sub
End Class