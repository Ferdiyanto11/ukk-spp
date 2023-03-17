Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing.Printing


Public Class Kelola_Laporan
    Dim PD As PrintDocument
    Dim PDD As New PrintPreviewDialog
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        printPD()
    End Sub
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim tinggi As Integer
        e.Graphics.DrawString("SPP SMK NEGERI 2 KUNINGAN", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 10
        e.Graphics.DrawString("No Tlp: 0812", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 10
        e.Graphics.DrawString("Jl.Sukamulya", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 20
        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 10
        e.Graphics.DrawString("tgl_bayar" & vbTab & vbTab & "jumlah_bayar", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 10
        e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        For Each data As DataGridViewRow In dgv_laporan.Rows
            tinggi = tinggi + 10
            e.Graphics.DrawString(data.Cells(0).Value, New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

            tinggi = tinggi + 10
            e.Graphics.DrawString(vbTab & vbTab & data.Cells(1).Value, New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)
        Next


        tinggi = tinggi + 10
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)

        tinggi = tinggi + 10
        e.Graphics.DrawString("Terimakasih...!!!", New Drawing.Font("courier new", 8), Brushes.Black, 2, tinggi)
    End Sub
    Sub printPD()
        PrintDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        PrintDoc.Print()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sql = "SELECT tgl_bayar, jumlah_bayar from pembayaran WHERE tgl_bayar between '" & dtdari.Value.Date.ToString("MM/dd/yyyy") & "' and '" & dtsampai.Value.Date.ToString("MM/dd/yyyy") & "'"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "pembayaran")
        dgv_laporan.DataSource = ds.Tables("pembayaran")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        sql = "SELECT tgl_bayar, jumlah_bayar from pembayaran WHERE tgl_bayar between '" & dtdari.Value.Date.ToString("MM/dd/yyyy") & "' and '" & dtsampai.Value.Date.ToString("MM/dd/yyyy") & "'"
        cmd = New SqlCommand(sql, con)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ChartLaporan.Series("omset").Points.AddXY(Microsoft.VisualBasic.Left(rd("tgl_bayar").ToString, 10), rd("jumlah_bayar").ToString)
        Loop
        rd.Close()
    End Sub

    Private Sub dgv_laporan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_laporan.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class