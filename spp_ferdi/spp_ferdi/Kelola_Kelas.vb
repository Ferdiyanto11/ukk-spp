Imports System.Data.SqlClient

Public Class Kelola_Kelas
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If Txtidkls.Text = "" And Txtnama.Text = "" And Txtkom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into kelas (id_kelas, nama_kelas, kompetensi_keahlian) VALUES ('" & Txtidkls.Text & "', '" & Txtnama.Text & "','" & Txtkom.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If Txtidkls.Text = "" And Txtnama.Text = "" And Txtkom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM kelas where id_kelas='" & Txtidkls.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub
    Sub aturdgv()
        sql = "SELECT * FROM kelas"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub
    Sub kosong()
        Txtidkls.Text = ""
        Txtnama.Text = ""
        Txtkom.Text = ""
        Txtcari.Text = ""

    End Sub
    Private Sub kelola_kelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        Txtidkls.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        Txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        Txtkom.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If Txtidkls.Text = "" And Txtnama.Text = "" And Txtkom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE kelas set nama_kelas='" & Txtnama.Text & "',kompetensi_keahlian= '" & Txtkom.Text & "'where id_kelas='" & Txtidkls.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub
    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * FROM kelas where (nama_kelas like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub
End Class