Imports System.Data.SqlClient
Public Class Kelola_Petugas
    Private Sub Kelola_Petugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If Txtidpeg.Text = "" And Txtnama.Text = "" And Txtpass.Text = "" And Txtpetugas.Text = "" And Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE petugas set username='" & Txtnama.Text & "',password= '" & Txtpass.Text & "',nama_petugas= '" & Txtpetugas.Text & "',level= '" & Cblevel.Text & "'where id_petugas='" & Txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Txtidpeg.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If Txtidpeg.Text = "" And Txtnama.Text = "" And Txtpass.Text = "" And Txtpetugas.Text = "" And Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into petugas (id_petugas, username, password, nama_petugas, level) VALUES ('" & Txtidpeg.Text & "', '" & Txtnama.Text & "','" & Txtpass.Text & "','" & Txtpetugas.Text & "','" & Cblevel.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If Txtidpeg.Text = "" And Txtnama.Text = "" And Txtpass.Text = "" And Txtpetugas.Text = "" And Cblevel.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM petugas where id_petugas='" & Txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        admin.Show()
        Me.Hide()
    End Sub
    Sub aturdgv()
        sql = "SELECT username, nama_petugas, level FROM petugas"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub
    Sub kosong()
        Txtidpeg.Text = ""
        Txtnama.Text = ""
        Txtpass.Text = ""
        Txtpetugas.Text = ""
        Cblevel.Text = ""
        Txtcari.Text = ""
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Login.Show()
        Me.Hide()
    End Sub
    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        Txtidpeg.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        Txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        Txtpass.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        Txtpetugas.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        Cblevel.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
    End Sub

    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * FROM petugas where (nama_petugas like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub

    Private Sub Cblevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cblevel.SelectedIndexChanged

    End Sub

    Private Sub Txtcari_TextChanged(sender As Object, e As EventArgs) Handles Txtcari.TextChanged

    End Sub
End Class