Imports DevExpress.XtraSpellChecker.Native
Imports DevExpress.XtraSpellChecker
Imports System.Globalization

Public Class Form2

    Dim SpellChecker1 As New DevExpress.XtraSpellChecker.SpellChecker

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SpellCheckTextControllersManager.Default.RegisterClass(GetType(CustomTextEdit), GetType(SimpleTextEditTextController))
        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(CustomTextEdit), GetType(TextEditTextBoxFinder))

        SpellCheckTextControllersManager.Default.RegisterClass(GetType(MyTextEdit), GetType(SimpleTextEditTextController))
        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(MyTextEdit), GetType(TextEditTextBoxFinder))

        'SpellCheckTextControllersManager.Default.RegisterClass(GetType(CustomRichEditControl), GetType(RichEditSpellCheckController))

        OnTutorialControlLoaded()

        SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        SpellChecker1.SetShowSpellCheckMenu(MyTextEdit1, True)
        SpellChecker1.SetShowSpellCheckMenu(CustomTextEdit1, True)
        SpellChecker1.SetShowSpellCheckMenu(RichEditControl1, True)
        SpellChecker1.OptionsSpelling.IgnoreUpperCaseWords = DevExpress.Utils.DefaultBoolean.False
        SpellChecker1.Check(CustomTextEdit1)
        SpellChecker1.Check(MyTextEdit1)

    End Sub


    Private Sub OnTutorialControlLoaded()
        If DesignMode Then
            Return
        End If
        Dim dictionaries As New DictionaryCollection

        Dim Dictionary As New LoadDictionary
        If dictionaries.Count = 0 Then
            Dictionary.PopulateDictionaries(dictionaries)
        End If

        If dictionaries.Count > 0 Then
            SpellChecker1.Dictionaries.Add(dictionaries(0))
            SpellChecker1.Culture = dictionaries(0).Culture
        Else
            SpellChecker1.Culture = CultureInfo.CurrentCulture
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SpellChecker1.Check(RichEditControl1)
    End Sub

    Private Sub RichEditControl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichEditControl1.KeyDown
        If (e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter) AndAlso e.Modifiers = Keys.None Then
            SpellChecker1.Check(RichEditControl1)
        End If
    End Sub
End Class