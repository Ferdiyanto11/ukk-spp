Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar

Public Class Kelola_Transaksi
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Sub aturdgv()
        sql = "SELECT nisn, tgl_bayar, bulan_dibayar, jumlah_bayar FROM pembayaran"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "pembayaran")
        dgv_user.DataSource = ds.Tables("pembayaran")
    End Sub

    Sub kosong()
        idptgs.Text = ""
        nisn.Text = ""
        Blnbyr.Text = ""
        Thnbyr.Text = ""
        idspp.Text = ""
        jmlbyr.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If Bayar.Text = "" And idptgs.Text = "" And nisn.Text = "" And Blnbyr.Text = "" And Thnbyr.Text = "" And idptgs.Text = "" And jmlbyr.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "INSERT into pembayaran (id_pembayaran, id_petugas, nisn, tgl_bayar, bulan_dibayar, tahun_dibayar, id_spp, jumlah_bayar) VALUES ('" & Bayar.Text & "', '" & idptgs.Text & "','" & nisn.Text & "','" & Format(dttbayar.Value, "yyyy-MM-dd") & "','" & Blnbyr.Text & "','" & Thnbyr.Text & "','" & idspp.Text & "','" & jmlbyr.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub
    Private Sub Kelola_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If Bayar.Text = "" And idptgs.Text = "" And nisn.Text = "" And Blnbyr.Text = "" And Thnbyr.Text = "" And idspp.Text = "" And jmlbyr.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "UPDATE pembayaran set id_petugas='" & idptgs.Text & "', nisn='" & nisn.Text & "', tgl_bayar='" & Format(dttbayar.Value, "yyyy-MM-dd") & "', bulan_dibayar='" & Blnbyr.Text & "', tahun_dibayar='" & Thnbyr.Text & "', id_spp='" & idspp.Text & "', jumlah_bayar='" & jmlbyr.Text & "' WHERE id_pembayaran='" & Bayar.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect()
        If Bayar.Text = "" And idptgs.Text = "" And nisn.Text = "" And Blnbyr.Text = "" And Thnbyr.Text = "" And idspp.Text = "" And jmlbyr.Text = "" Then
            MsgBox("Pastikan semua field terisi")
        Else
            sql = "DELETE FROM pembayaran where id_pembayaran='" & Bayar.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Petugas.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Login.Show()
        Me.Hide()
    End Sub
    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        Bayar.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        idptgs.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        nisn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        dttbayar.Value = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        Blnbyr.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
        Thnbyr.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(5).Value
        idspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(6).Value
        jmlbyr.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(7).Value
    End Sub
    Private Sub PrintPD_Click(sender As Object, e As EventArgs) Handles PrintPD.Click
        'printPD()
        PDD.Document = PD
        PDD.ShowDialog()
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14 As New Font("Times New Roman", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "--------------------------------------------------------------------------------------"

        e.Graphics.DrawString("SPP SMK Negeri 2 Kuningan", f14, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl.Sukamulya No.77", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("No Tlp: 0812", f10, Brushes.Black, centermargin, 40, tengah)

        e.Graphics.DrawString("Petugas", f10, Brushes.Black, 0, 65)
        e.Graphics.DrawString(":", f10, Brushes.Black, 60, 65)
        e.Graphics.DrawString("Ferdi", f10, Brushes.Black, 80, 65)

        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 80)
        e.Graphics.DrawString("nisn", f10, Brushes.Black, 135, 95)
        e.Graphics.DrawString("harga", f10, Brushes.Black, 170, 95)
        e.Graphics.DrawString("tanggal bayar", f10, Brushes.Black, 220, 95)
        dgv_user.AllowUserToAddRows = False

        Dim tinggi As Integer
        For baris As Integer = 0 To dgv_user.RowCount - 1
            tinggi += 15
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(0).Value.ToString, f10, Brushes.Black, 0, 100 + tinggi)
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(1).Value.ToString, f10, Brushes.Black, 70, 100 + tinggi)
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(2).Value.ToString, f10, Brushes.Black, 135, 100 + tinggi)



        Next
        tinggi = 110 + tinggi
        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 400)
        e.Graphics.DrawString("Terimakasih:)", f10, Brushes.Black, centermargin, 450, tengah)


    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 350, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub
    Private Sub Txtcari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcari.KeyPress
        sql = "SELECT * FROM pembayaran where (id_pembayaran like '%" & Txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub
    Private Sub jmlbyr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles jmlbyr.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan Angka Yang Di Inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub Txtcari_TextChanged(sender As Object, e As EventArgs) Handles Txtcari.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        If txtkembali.Text = 2000000 Then
            MsgBox("Uang Anda Lebih")
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Label10.Text = 1000000
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Label11.Text = 100000
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        admin.Show()
        Me.Hide()
    End Sub

    Private Sub Txtkembali_TextChanged(sender As Object, e As EventArgs) Handles Txtkembali.TextChanged

    End Sub
End Class