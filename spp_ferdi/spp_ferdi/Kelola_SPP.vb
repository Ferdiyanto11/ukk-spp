Imports System.Data.SqlClient

Public Class Kelola_SPP
    Sub aturdgv()
        sql = "SELECT * FROM spp"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub
    Sub kosong()
        cbidspp.Text = ""
        txtthn.Text = ""
        Txtnom.Text = ""
        Txtcari.Text = ""
    End Sub
    Private Sub kelola_spp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If cbidspp.Text = "" And txtthn.Text = "" And Txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into spp (id_spp, tahun, nominal) VALUES ('" & cbidspp.Text & "', '" & txtthn.Text & "','" & Txtnom.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If cbidspp.Text = "" And txtthn.Text = "" And Txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE spp set tahun='" & txtthn.Text & "',nominal= '" & Txtnom.Text & "'where id_spp='" & cbidspp.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If cbidspp.Text = "" And txtthn.Text = "" And Txtnom.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM spp where id_spp='" & cbidspp.Text & "'"
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

    Private Sub dgv_user_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_user.CellContentClick
        cbidspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtthn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        Txtnom.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value

    End Sub
    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * FROM spp where (tahun like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub
End Class