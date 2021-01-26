Public Class login

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        login_valid = oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            MessageBox.Show("selamat datang")
            Form1.Show()
            Me.Hide()
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub
End Class