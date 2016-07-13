' ============================================================================ '
' =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
' =                                                                          = '
' =  Permission to use, copy, modify, and distribute this software and its   = '
' =  documentation for any purpose, without fee, and without a written       = '
' =  agreement, is here by granted, provided that the above copyright notice,= '
' =  this paragraph and the following two paragraphs appear in all copies,   = '
' =  modifications, and distributions.  Created by:                          = '
' =                                                                          = '
' =                        M.M..S.O.F.T.W.A.R.E                              = '
' =                                                                          = '
' =  MM Software Co., Ltd, 35 Tan Vinh Street, Ward 4                        = '
' =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
' =  For technical information, contact mmsoftvn@gmail.com                   = '
' =                                                                          = '
' =  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
' =  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
' =  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
' =  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
' =                                                                          = '
' =  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
' =  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
' =  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
' =  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
' =  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
' =  MODIFICATIONS.                                                          = '
' ============================================================================ '

Imports System.Web.Configuration
Imports System.Configuration

Partial Class Interfaces_System_Config_pgInterfaceConfi
    Inherits System.Web.UI.Page

    Dim appSec As AppSettingsSection
    Dim config As Configuration
    Dim strContainer As String
    Dim strCheck As String
    Dim arrValue, arrCopy, arrCopied As New ArrayList


    Public Sub myUpload(ByVal posted As System.Web.HttpPostedFile, ByVal intCase As Integer)
        If Not posted Is Nothing Then
            Try

                Dim intCount As String = posted.FileName.Length - 3
                'strCheck = upLogo.PostedFile.FileName.Substring(intCount, 3)
                strCheck = posted.FileName.Substring(intCount, 3)
                strCheck = strCheck.ToLower()
                If strCheck.ToLower() <> "jpg" And strCheck <> "gif" And strCheck <> "png" And strCheck <> "bmp" And strCheck <> "jpe" Then
                    lblWarning.Text = "Please choose a photo to upload..."
                Else
                    Dim filepath As String = posted.FileName
                    Dim strFile As String = System.IO.Path.GetFileName(filepath).Trim()
                    Dim filename As String = strFile.Substring(0, strFile.Length - 4).Trim() ' get file name
                    Dim file_ext As String = strFile.Substring(strFile.Length - 3).Trim() ' get file extention

                    'Dim pat As String = "\\(?:.+)\\(.+)\.(.+)"
                    'Dim r As Regex = New Regex(pat)
                    ''run
                    'Dim m As Match = r.Match(filepath)
                    'Dim file_ext As String = m.Groups(2).Captures(0).ToString()
                    'Dim filename As String = m.Groups(1).Captures(0).ToString()
                    Dim file As String = filename & "." & file_ext

                    'save the file to the server 
                    If intCase = 1 Then
                        posted.SaveAs(Server.MapPath(".\") & "IntelliVueLogo.jpg")
                    ElseIf intCase = 2 Then
                        posted.SaveAs(Server.MapPath(".\") & "MiddleBanner.jpg")
                    ElseIf intCase = 3 Then
                        posted.SaveAs(Server.MapPath(".\") & "Photo.jpg")
                    End If
                    lblWarning.Text = "Upload Successfully........."
                End If

            Catch ex As Exception
                lblWarning.Text = "Can't update new image. Please try again........"
            End Try
        End If
    End Sub

    Protected Sub cmdUploadLogo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUploadLogo.Click
        If upLogo.PostedFile.FileName <> "" Then
            myUpload(upLogo.PostedFile, 1)
        Else
            lblWarning.Text = "Please choose a photo to upload..."
        End If
    End Sub

    Protected Sub cmdUploadBanner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUploadBanner.Click
        If upBanner.PostedFile.FileName <> "" Then
            myUpload(upBanner.PostedFile, 2)
        Else
            lblWarning.Text = "Please choose a photo to upload..."
        End If
    End Sub

    Protected Sub cmdUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUploadImage.Click
        If upImage.PostedFile.FileName <> "" Then
            myUpload(upImage.PostedFile, 3)
        Else
            lblWarning.Text = "Please choose a photo to upload..."
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") IsNot Nothing Then
            If Session("username").ToString().ToLower() = "intellivue" Then
                If IsPostBack = False Then
                    mainConfig(1, 0, 0, 0)
                    'lblAlert.Text = arrValue.ToString()
                End If
            End If
        Else
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
    'This function is used to config the web servies file.
    Public Sub mainConfig(ByVal intFill As Integer, ByVal intDelete As Integer, ByVal _
                      intAddNew As Integer, ByVal intModify As Integer)


        config = WebConfigurationManager.OpenWebConfiguration("~")
        appSec = New AppSettingsSection
        appSec = config.GetSection("appSettings")
        Dim strKey As String
        If intFill = 1 Then
            Try
                For Each strKey In appSec.Settings.AllKeys
                    cboKey.Items.Add(strKey)
                    arrValue.Add(System.Configuration.ConfigurationManager.AppSettings(strKey))
                Next
            Catch ex As Exception
                lblAlert.Text = "Cannot get source. Please refresh your browser!"
            End Try
        ElseIf intDelete = 1 Then
            Try
                appSec.Settings.Remove(cboKey.SelectedValue)
                Dim intPosition As Integer = cboKey.SelectedIndex
                cboKey.Items.RemoveAt(intPosition)
                txtSourceValue.Text = ""
                config.Save()
                lblAlert.Text = "Delete Successful!"
            Catch ex As Exception
                lblAlert.Text = "Delete Successful.Please try again!"
            End Try
        ElseIf intAddNew = 1 Then
            Try
                appSec.Settings.Add(txtNewKey.Text, txtNewValue.Text)
                config.Save()
                txtNewKey.Text = ""
                txtNewValue.Text = ""
                lblAlert.Text = "Add New Successful!"
            Catch ex As Exception
                lblAlert.Text = "Add New Unsuccessful.Please try again!"
            End Try
        ElseIf intModify = 1 Then
            Try
                appSec.Settings.Remove(cboKey.SelectedValue)
                appSec.Settings.Add(cboKey.SelectedValue, txtSourceValue.Text)
                config.Save()
                lblAlert.Text = "Modify Successful!"
            Catch ex As Exception
                lblAlert.Text = "Modify unsuccessful.Please try again!"
            End Try
        End If

    End Sub
    'End

    Protected Sub cboKey_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboKey.SelectedIndexChanged
        strContainer = cboKey.SelectedValue
        txtSourceValue.Text = System.Configuration.ConfigurationManager.AppSettings(strContainer)
    End Sub

    Protected Sub cmdModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdModify.Click
        If cboKey.SelectedItem.ToString() <> "-- Select a key --" Then
            mainConfig(0, 0, 0, 1)
        Else
            lblAlert.Text = "Please choose a key......."
        End If
    End Sub

    Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        mainConfig(0, 1, 0, 0)
    End Sub

    Protected Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        If txtNewKey.Text <> "" And txtNewValue.Text <> "" Then
            mainConfig(0, 0, 1, 0)
            cboKey.Items.Clear()
            mainConfig(1, 0, 0, 0)
        Else
            lblAlert.Text = "Please fill value into the New Key and the New Value text fields before add..."
        End If
    End Sub
End Class
