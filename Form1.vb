Public Class Form1
    Private Sub btnservice_Click(sender As System.Object, e As System.EventArgs) Handles btnservice.Click
        If (menu_service = False) Then
            BikinMenu(cldService, TabControl1, "Service")
            menu_service = True
        Else
            x = getTabIndex(TabControl1, "Service")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnsparepart_Click(sender As System.Object, e As System.EventArgs) Handles btnsparepart.Click
        If (menu_sparepart = False) Then
            BikinMenu(cldSparepart, TabControl1, "Spare Part")
            menu_sparepart = True
        Else
            x = getTabIndex(TabControl1, "Spare Part")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If


        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Service") Then
            menu_service = False
        ElseIf (itemToRemove.ToString = "Spare Part") Then
            menu_sparepart = False
        ElseIf (itemToRemove.ToString = "Transaksi") Then
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub
End Class
