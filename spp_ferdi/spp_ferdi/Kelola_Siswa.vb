Imports System.Data.SqlClient

Public Class Kelola_Siswa
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Sub aturdgv()
        sql = "SELECT nisn, nama,alamat, no_telp  FROM siswa"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "siswa")
        dgv_user.DataSource = ds.Tables("siswa")
    End Sub
    Sub kosong()
        Txtnisn.Text = ""
        Txtnis.Text = ""
        Txtnama.Text = ""
        Txtidkls.Text = ""
        Txtalmt.Text = ""
        Txttlpn.Text = ""
        cbidspp.Text = ""
        txtcari.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If Txtnisn.Text = "" And Txtnis.Text = "" And Txtnama.Text = "" And Txtidkls.Text = "" And Txtalmt.Text = "" And Txttlpn.Text = "" And cbidspp.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into siswa (nisn, nis, nama, id_kelas, alamat, no_telp, id_spp) VALUES ('" & Txtnisn.Text & "', '" & Txtnis.Text & "','" & Txtnama.Text & "','" & Txtidkls.Text & "','" & Txtalmt.Text & "','" & Txttlpn.Text & "','" & cbidspp.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If Txtnisn.Text = "" And Txtnis.Text = "" And Txtnama.Text = "" And Txtidkls.Text = "" And Txtalmt.Text = "" And Txttlpn.Text = "" And cbidspp.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM siswa where nisn='" & Txtnisn.Text & "'"
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If Txtnisn.Text = "" And Txtnis.Text = "" And Txtnama.Text = "" And Txtidkls.Text = "" And Txtalmt.Text = "" And Txttlpn.Text = "" And cbidspp.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE siswa set nis='" & Txtnis.Text & "',nama= '" & Txtnama.Text & "',id_kelas= '" & Txtidkls.Text & "',alamat= '" & Txtalmt.Text & "',no_telp= '" & Txttlpn.Text & "',id_spp= '" & cbidspp.Text & "'where nisn='" & Txtnisn.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub dgv_user_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_user.CellContentClick
        Txtnisn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        Txtnis.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        Txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        Txtidkls.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        Txtalmt.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
        Txttlpn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(5).Value
        cbidspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(6).Value
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Kelola_Siswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub
    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * FROM siswa where (nama like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "Siswa")
        dgv_user.DataSource = ds.Tables("Siswa")
    End Sub

    Private Sub Txtalmt_TextChanged(sender As Object, e As EventArgs) Handles Txtalmt.TextChanged

    End Sub
End Class