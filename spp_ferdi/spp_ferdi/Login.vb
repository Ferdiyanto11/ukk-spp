Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles

Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        If Txtnm.Text = "" And Txtpass.Text = "" Then
            MsgBox("Pastikan Mengisi Semua Field")
        Else
            sql = "SELECT id_petugas, username, password, level FROM petugas WHERE username='" & Trim(Txtnm.Text) & "' and password='" & Trim(Txtpass.Text) & "'"
            cmd = New SqlCommand(sql, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                If rd.Item("level").Equals("Admin") Then
                    admin.Show()
                    Me.Hide()
                ElseIf rd.Item("level").Equals("Petugas") Then
                    Petugas.Show()
                    Me.Hide()
                ElseIf rd.Item("level").Equals("Siswa") Then
                    Siswa.Show()
                    Me.Hide()
                Else
                    MsgBox("Username atau password yang anda masukan tidak sesuai")
                    rd.Close()
                End If
            Else
                MsgBox("Username atau password yang anda masukan tidak sesuai")
                rd.Close()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Txtnm.Text = ""
        Txtpass.Text = ""
        MsgBox("Username Dan password anda berhasil di reset")
        rd.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txtpass.UseSystemPasswordChar = True
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            Txtpass.UseSystemPasswordChar = False
        Else
            Txtpass.UseSystemPasswordChar = True
        End If
    End Sub
End Class
