Imports DevExpress.XtraSpellChecker
Imports System.IO
Imports DevExpress.Utils.Zip

Imports System.Globalization

Public Class Form1

    Private Sub OnTutorialControlLoaded()
        If DesignMode Then
            Return
        End If
        Dim dictionaries As DictionaryCollection
        If SpellChecker1.UseSharedDictionaries Then
            dictionaries = SharedDictionaryStorage1.Dictionaries
        Else
            dictionaries = SpellChecker1.Dictionaries
        End If
        Dim Dictionary As New LoadDictionary
        If dictionaries.Count = 0 Then
            Dictionary.PopulateDictionaries(dictionaries)
        End If
        If dictionaries.Count > 0 Then
            SpellChecker1.Culture = dictionaries(0).Culture
        Else
            SpellChecker1.Culture = CultureInfo.CurrentCulture
        End If

        SpellChecker1.Check(Me.TextEdit1)
        SpellChecker1.Check(Me.TextEdit2)
        SpellChecker1.Check(Me.MemoEdit1)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SpellChecker1.SpellingFormType = SpellingFormType.Word
        SpellChecker1.SpellCheckMode = SpellCheckMode.AsYouType
        OnTutorialControlLoaded()
        'GridControl1.DataSource = Collection(Of Employee)()
    End Sub

#Region "Do Check"

    'Private Sub DoCheck(ByVal uControl As Control)
    '    ' uControl.Text = SpellChecker1.Check(uControl.Text)
    '    SpellChecker1.Check(uControl)
    'End Sub

#End Region

#Region "Private Events"

    'Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextEdit1.KeyDown
    '    ' If (e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter) AndAlso e.Modifiers = Keys.None Then
    '    DoCheck(Me.TextEdit1)
    '    ' End If
    'End Sub

    'Private Sub MemoEdit1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MemoEdit1.KeyDown
    '    If (e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter) AndAlso e.Modifiers = Keys.None Then
    '        DoCheck(Me.MemoEdit1)
    '    End If
    'End Sub

    'Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextEdit2.KeyDown
    '    If (e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter) AndAlso e.Modifiers = Keys.None Then
    '        DoCheck(Me.TextEdit2)
    '    End If
    'End Sub

    'Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
    '    SpellChecker1.Check(CType(sender, DevExpress.XtraGrid.Views.Grid.GridView).ActiveEditor)
    '    SpellChecker1.SetShowSpellCheckMenu(CType(sender, DevExpress.XtraGrid.Views.Grid.GridView).ActiveEditor, True)
    'End Sub

#End Region


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
        MsgBox(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments))
    End Sub
End Class
