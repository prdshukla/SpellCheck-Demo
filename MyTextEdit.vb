Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.XtraEditors

Public Class MyTextEdit
    Inherits TextEdit


    Private mEnableTabKeyEvent As Boolean = False
    Private mDefaultValue As Boolean = False
    Private mOFFCapsValidation As Boolean = True
    Private mCapitalization As Boolean = True

#Region "Properties"

    Public Property EnableTabKeyEvent() As Boolean
        Get
            Return mEnableTabKeyEvent
        End Get
        Set(ByVal value As Boolean)
            mEnableTabKeyEvent = value
        End Set
    End Property

    '''' <summary>
    '''' Property to set the default values as zero
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    <Description("Default value zero is required or not"), Category("Custom Properties"), Browsable(True), RefreshProperties(RefreshProperties.Repaint)> _
    Public Property RequiredZeroAsDefaultValue() As Boolean
        Get
            Return Me.mDefaultValue
        End Get
        Set(ByVal value As Boolean)
            Me.mDefaultValue = value
        End Set
    End Property

    ''' <summary>
    ''' Property That will allow the User to Get or Set Is Convert into Capital letter on Key Press.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Convert Key Stroke into Capital Letter"), Category("Custom Properties"), Browsable(True), DefaultValue(True)> _
    Public Property OffCapsValidation() As Boolean
        Get
            Return mOFFCapsValidation
        End Get
        Set(ByVal value As Boolean)
            mOFFCapsValidation = value
        End Set
    End Property

    ''' <summary>
    ''' This Property can be set from Form level. The System omit the Capitalization Rules if this property is False.
    ''' By default, this is True
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CapitalizationRule() As Boolean
        Get
            Return mCapitalization
        End Get
        Set(ByVal value As Boolean)
            mCapitalization = value
        End Set
    End Property
#End Region

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)
        'Me.Properties.CharacterCasing = CharacterCasing.Upper
    End Sub

    Protected Overrides Sub InitLayout()
        MyBase.InitLayout()
        'If UIControlConstants.UseCustomSkin Then
        'Me.LookAndFeel.UseDefaultLookAndFeel = UIControlConstants.UseDefaultLookAndFeel
        'Me.LookAndFeel.SkinName = UIControlConstants.CommonSkin
        'Me.Font = New System.Drawing.Font(TryCast(UIControlConstants.FontName, String), CType(UIControlConstants.FontSize, Single), FontStyle.Regular)
        'Me.ForeColor = Color.Black
        'Else
        Me.LookAndFeel.UseDefaultLookAndFeel = True
        Me.LookAndFeel.SkinName = "The Asphalt World"
        Me.LookAndFeel.SetSkinStyle("The Asphalt World")
        'End If
        Me.Properties.AppearanceReadOnly.BackColor = Color.LightGray
    End Sub


    ''' <summary>
    ''' For validating the Input key
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If EnableTabKeyEvent Then
            If keyData = Keys.Tab Then
                Return True
            End If
        End If
        Return MyBase.IsInputKey(keyData)
    End Function

    ''' <summary>
    ''' For validating Text Values
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CustomTextEdit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim objTextEdit As MyTextEdit = CType(sender, MyTextEdit)
        If (objTextEdit.Text = String.Empty Or objTextEdit.Text = ". ") _
                    And objTextEdit.Properties.Mask.EditMask <> String.Empty _
                    And ((objTextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx) _
                    Or (objTextEdit.Properties.Mask.MaskType = Mask.MaskType.Numeric)) Then
            If mDefaultValue Then
                objTextEdit.Text = "0"
            Else
                objTextEdit.Text = String.Empty
            End If
        End If
    End Sub

    ' ''' <summary>
    ' ''' To Convert Key Stroke into Capital Letter if Set as True
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    Private Sub CustomTextEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not CType(sender, MyTextEdit).OffCapsValidation Then
            e.KeyChar = CChar((e.KeyChar).ToString.ToUpper(CultureInfo.CurrentCulture))
            'Char.ToUpper(e.KeyChar)
        End If
    End Sub

    ''' <summary>
    ''' To Capitalize the First character
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CustomTextEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CapitalizationRule) Then
            Dim value As String = Me.Text.Trim
            If Not value = String.Empty Then
                Dim firstStr As String
                Dim remStr As String
                firstStr = value.Substring(0, 1).ToString(CultureInfo.InvariantCulture)
                remStr = value.Substring(1, value.Length - 1)
                value = firstStr + remStr
                Me.Text = value.ToUpperInvariant()
                Me.ToolTip = Me.Text
            End If
        End If
    End Sub

    ''' <summary>
    ''' To match the tool tip to the text on clearing the value
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CustomTextEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ToolTip = Me.Text.ToUpperInvariant
    End Sub
End Class
