Imports DevExpress.XtraSpellChecker
Imports System.IO
Imports DevExpress.Utils.Zip
Imports System.Globalization
Imports System
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word

Public Class LoadDictionary
    Private emptyItem As Object = System.Reflection.Missing.Value
    Private oNothing As Object = Nothing
    Private oTrue As Object = True
    Private oFalse As Object = False
    Private oAlwaysSuggest As Object = True
    Private oIgnoreUpperCase As Object = False
    Private mAlwaysSuggest As Boolean = True
    Private mIgnoreUpperCase As Boolean = False

#Region "Dictionary Approach"

    Public Sub PopulateDictionaries(ByVal dictionaries As DictionaryCollection)
        dictionaries.Add(GetDefaultDictionary())
        Dim customDictionary As New SpellCheckerCustomDictionary(GetRelativePath("Dictionaries\CustomEnglish.dic"), New CultureInfo("en-US"))
        dictionaries.Add(customDictionary)
    End Sub

    Protected Function GetDefaultDictionary() As ISpellCheckerDictionary
        Dim dic As New SpellCheckerISpellDictionary()
        Dim zipFileStream As Stream = GetFileStream("Dictionaries\default.zip")
        Dim files As ZipFileCollection = ZipArchive.Open(zipFileStream)
        Dim alphabetStream As Stream = GetFileStream("Dictionaries\EnglishAlphabet.txt")
        Try
            dic.LoadFromStream(GetFileStream(files, "american.xlg"), GetFileStream(files, "english.aff"), alphabetStream)
        Catch
        Finally
            zipFileStream.Dispose()
            alphabetStream.Dispose()
            DisposeZipFileStreams(files)
        End Try
        dic.Culture = New CultureInfo("en-US")
        Return dic
    End Function

    Protected Function GetFileStream(ByVal relativeUri As String) As Stream
        Return New FileStream(GetRelativePath(relativeUri), FileMode.Open, FileAccess.Read, FileShare.Read)
    End Function

    Protected Function GetFileStream(ByVal files As ZipFileCollection, ByVal name As String) As Stream
        For Each file As ZipFile In files
            If file.FileName.IndexOf(name) >= 0 Then
                Return file.FileDataStream
            End If
        Next file
        Return Nothing
    End Function

    Protected Sub DisposeZipFileStreams(ByVal files As ZipFileCollection)
        For Each file As ZipFile In files
            file.FileDataStream.Dispose()
        Next file
    End Sub

    Protected Shared Function GetRelativePath(ByVal name As String) As String
        Dim path As String = System.Windows.Forms.Application.StartupPath
        Dim s As String = "\"
        For i As Integer = 0 To 10
            If System.IO.File.Exists(path & s & name) Then
                Return (path & s & name)
            Else
                s &= "..\"
            End If
        Next i
        path = Environment.CurrentDirectory
        s = "\"
        For i As Integer = 0 To 10
            If System.IO.File.Exists(path & s & name) Then
                Return (path & s & name)
            Else
                s &= "..\"
            End If
        Next i
        Return ""
    End Function
#End Region

#Region "SpellCheck Control"

    Public Sub CheckSpelling(ByVal sText As String)

        ' declare local variables to track error count
        ' and information
        Dim SpellingErrors As Integer = 0
        Dim ErrorCountMessage As String = String.Empty

        ' create an instance of a word application
        ' hide the MS Word document during the spellcheck
        Dim WordApp As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application() With {.Visible = False}
        ' WordApp.ShowWindowsInTaskbar = False

        ' check for zero length content in text area
        If sText.Length > 0 Then

            ' create an instance of a word document
            Dim WordDoc As _Document = WordApp.Documents.Add(emptyItem, emptyItem, emptyItem, oFalse)

            ' load the content written into the word doc
            WordDoc.Words.First.InsertBefore(sText)

            ' collect errors form new temporary document set to contain
            ' the content of this control
            Dim docErrors As Microsoft.Office.Interop.Word.ProofreadingErrors = WordDoc.SpellingErrors
            SpellingErrors = docErrors.Count

            ' execute spell check; assumes no custom dictionaries
            WordDoc.CheckSpelling(oNothing, oIgnoreUpperCase, oAlwaysSuggest,
                oNothing, oNothing, oNothing, oNothing, oNothing, _
                oNothing, oNothing, oNothing, oNothing)

            ' format a string to contain a report of the errors detected
            ErrorCountMessage = "Spell check complete; errors detected: " +
            SpellingErrors.ToString()

            ' return corrected text to control's text area
            Dim first As Object = 0
            Dim last As Object = WordDoc.Characters.Count - 1
            sText = WordDoc.Range(first, last).Text

        Else

            ' if nothing was typed into the control, abort and inform user
            ErrorCountMessage = "Unable to spell check an empty text box."


            WordApp.Quit(oFalse, emptyItem, emptyItem)

            ' return report on errors corrected
            ' - could either display from the control or change this to
            ' - return a string which the caller could use as desired.
            MessageBox.Show(ErrorCountMessage, "Finished Spelling Check")

        End If

    End Sub


#End Region


End Class
