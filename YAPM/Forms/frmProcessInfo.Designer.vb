﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessInfo
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessInfo))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Strings", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Strings", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Search result", System.Windows.Forms.HorizontalAlignment.Left)
        Me.tabProcess = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtProcessUser = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtProcessId = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtProcessStarted = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtParentProcess = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.gpProcGeneralFile = New System.Windows.Forms.GroupBox
        Me.cmdShowFileDetails = New System.Windows.Forms.Button
        Me.cmdShowFileProperties = New System.Windows.Forms.Button
        Me.cmdOpenDirectory = New System.Windows.Forms.Button
        Me.txtProcessPath = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtImageVersion = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.pctSmallIcon = New System.Windows.Forms.PictureBox
        Me.menuCopyPctSmall = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.pctBigIcon = New System.Windows.Forms.PictureBox
        Me.menuCopyPctbig = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblUserObjectsCount = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.lblGDIcount = New System.Windows.Forms.Label
        Me.lbl789 = New System.Windows.Forms.Label
        Me.lblHandles = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblProcOtherBytes = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lblProcOther = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lblProcWriteBytes = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.lblProcWrites = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lblProcReadBytes = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblProcReads = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblQuotaNPP = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblQuotaPNPP = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblQuotaPP = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lblQuotaPPP = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblPageFaults = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.lblPeakPageFileUsage = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.lblPageFileUsage = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblPeakWorkingSet = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblWorkingSet = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTotalTime = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblUserTime = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblKernelTime = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblPriority = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.splitPerformances = New System.Windows.Forms.SplitContainer
        Me.graphCPU = New YAPM.Graph2
        Me.splitPerformance2 = New System.Windows.Forms.SplitContainer
        Me.graphMemory = New YAPM.Graph2
        Me.graphIO = New YAPM.Graph2
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.tabProcessToken = New System.Windows.Forms.TabControl
        Me.tabProcessTokenPagePrivileges = New System.Windows.Forms.TabPage
        Me.lvPrivileges = New YAPM.DoubleBufferedLV
        Me.ColumnHeader50 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader51 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader52 = New System.Windows.Forms.ColumnHeader
        Me.menuPrivileges = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem44 = New System.Windows.Forms.ToolStripMenuItem
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.lvProcMem = New YAPM.DoubleBufferedLV
        Me.ColumnHeader53 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader54 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader55 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader56 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.menuProcMem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem49 = New System.Windows.Forms.ToolStripMenuItem
        Me.JumpToPEBAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.SplitContainerInfoProcess = New System.Windows.Forms.SplitContainer
        Me.chkDisplayNAProcess = New System.Windows.Forms.CheckBox
        Me.chkHandles = New System.Windows.Forms.CheckBox
        Me.chkOnline = New System.Windows.Forms.CheckBox
        Me.chkModules = New System.Windows.Forms.CheckBox
        Me.cmdInfosToClipB = New System.Windows.Forms.Button
        Me.rtb = New System.Windows.Forms.RichTextBox
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.lvProcServices = New YAPM.DoubleBufferedLV
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader47 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader48 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.menuProcServ = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem43 = New System.Windows.Forms.ToolStripMenuItem
        Me.tabNetwork = New System.Windows.Forms.TabPage
        Me.lvProcNetwork = New YAPM.DoubleBufferedLV
        Me.ColumnHeader49 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader57 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader58 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader59 = New System.Windows.Forms.ColumnHeader
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.SplitContainerStrings = New System.Windows.Forms.SplitContainer
        Me.lvProcString = New YAPM.DoubleBufferedLV
        Me.ColumnHeader76 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader77 = New System.Windows.Forms.ColumnHeader
        Me.cmdProcSearchR = New System.Windows.Forms.Button
        Me.cmdProcSearchL = New System.Windows.Forms.Button
        Me.pgbString = New System.Windows.Forms.ProgressBar
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtSearchProcString = New System.Windows.Forms.TextBox
        Me.cmdProcStringSave = New System.Windows.Forms.Button
        Me.optProcStringMemory = New System.Windows.Forms.RadioButton
        Me.optProcStringImage = New System.Windows.Forms.RadioButton
        Me.TabPage9 = New System.Windows.Forms.TabPage
        Me.lvProcEnv = New YAPM.DoubleBufferedLV
        Me.ColumnHeader60 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader61 = New System.Windows.Forms.ColumnHeader
        Me.timerProcPerf = New System.Windows.Forms.Timer(Me.components)
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.imgProcess = New System.Windows.Forms.ImageList(Me.components)
        Me.tabProcess.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpProcGeneralFile.SuspendLayout()
        CType(Me.pctSmallIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCopyPctSmall.SuspendLayout()
        CType(Me.pctBigIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCopyPctbig.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.splitPerformances.Panel1.SuspendLayout()
        Me.splitPerformances.Panel2.SuspendLayout()
        Me.splitPerformances.SuspendLayout()
        CType(Me.graphCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitPerformance2.Panel1.SuspendLayout()
        Me.splitPerformance2.Panel2.SuspendLayout()
        Me.splitPerformance2.SuspendLayout()
        CType(Me.graphMemory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graphIO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.tabProcessToken.SuspendLayout()
        Me.tabProcessTokenPagePrivileges.SuspendLayout()
        Me.menuPrivileges.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.menuProcMem.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SplitContainerInfoProcess.Panel1.SuspendLayout()
        Me.SplitContainerInfoProcess.Panel2.SuspendLayout()
        Me.SplitContainerInfoProcess.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.menuProcServ.SuspendLayout()
        Me.tabNetwork.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.SplitContainerStrings.Panel1.SuspendLayout()
        Me.SplitContainerStrings.Panel2.SuspendLayout()
        Me.SplitContainerStrings.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabProcess
        '
        Me.tabProcess.Controls.Add(Me.TabPage1)
        Me.tabProcess.Controls.Add(Me.TabPage2)
        Me.tabProcess.Controls.Add(Me.TabPage3)
        Me.tabProcess.Controls.Add(Me.TabPage4)
        Me.tabProcess.Controls.Add(Me.TabPage5)
        Me.tabProcess.Controls.Add(Me.TabPage6)
        Me.tabProcess.Controls.Add(Me.TabPage7)
        Me.tabProcess.Controls.Add(Me.tabNetwork)
        Me.tabProcess.Controls.Add(Me.TabPage8)
        Me.tabProcess.Controls.Add(Me.TabPage9)
        Me.tabProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProcess.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabProcess.Location = New System.Drawing.Point(0, 0)
        Me.tabProcess.Name = "tabProcess"
        Me.tabProcess.SelectedIndex = 0
        Me.tabProcess.Size = New System.Drawing.Size(644, 284)
        Me.tabProcess.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.gpProcGeneralFile)
        Me.TabPage1.ImageIndex = 0
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(636, 258)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProcessUser)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtProcessId)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtProcessStarted)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtParentProcess)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 119)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'txtProcessUser
        '
        Me.txtProcessUser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProcessUser.Location = New System.Drawing.Point(89, 90)
        Me.txtProcessUser.Name = "txtProcessUser"
        Me.txtProcessUser.ReadOnly = True
        Me.txtProcessUser.Size = New System.Drawing.Size(283, 22)
        Me.txtProcessUser.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "User"
        '
        'txtProcessId
        '
        Me.txtProcessId.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProcessId.Location = New System.Drawing.Point(89, 67)
        Me.txtProcessId.Name = "txtProcessId"
        Me.txtProcessId.ReadOnly = True
        Me.txtProcessId.Size = New System.Drawing.Size(282, 22)
        Me.txtProcessId.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(23, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Pid"
        '
        'txtProcessStarted
        '
        Me.txtProcessStarted.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProcessStarted.Location = New System.Drawing.Point(90, 45)
        Me.txtProcessStarted.Name = "txtProcessStarted"
        Me.txtProcessStarted.ReadOnly = True
        Me.txtProcessStarted.Size = New System.Drawing.Size(281, 22)
        Me.txtProcessStarted.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Started"
        '
        'txtParentProcess
        '
        Me.txtParentProcess.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtParentProcess.Location = New System.Drawing.Point(90, 22)
        Me.txtParentProcess.Name = "txtParentProcess"
        Me.txtParentProcess.ReadOnly = True
        Me.txtParentProcess.Size = New System.Drawing.Size(280, 22)
        Me.txtParentProcess.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Parent process"
        '
        'gpProcGeneralFile
        '
        Me.gpProcGeneralFile.Controls.Add(Me.cmdShowFileDetails)
        Me.gpProcGeneralFile.Controls.Add(Me.cmdShowFileProperties)
        Me.gpProcGeneralFile.Controls.Add(Me.cmdOpenDirectory)
        Me.gpProcGeneralFile.Controls.Add(Me.txtProcessPath)
        Me.gpProcGeneralFile.Controls.Add(Me.Label13)
        Me.gpProcGeneralFile.Controls.Add(Me.txtImageVersion)
        Me.gpProcGeneralFile.Controls.Add(Me.Label12)
        Me.gpProcGeneralFile.Controls.Add(Me.lblCopyright)
        Me.gpProcGeneralFile.Controls.Add(Me.lblDescription)
        Me.gpProcGeneralFile.Controls.Add(Me.pctSmallIcon)
        Me.gpProcGeneralFile.Controls.Add(Me.pctBigIcon)
        Me.gpProcGeneralFile.Location = New System.Drawing.Point(6, 6)
        Me.gpProcGeneralFile.Name = "gpProcGeneralFile"
        Me.gpProcGeneralFile.Size = New System.Drawing.Size(376, 117)
        Me.gpProcGeneralFile.TabIndex = 15
        Me.gpProcGeneralFile.TabStop = False
        Me.gpProcGeneralFile.Text = "Image file"
        '
        'cmdShowFileDetails
        '
        Me.cmdShowFileDetails.Image = CType(resources.GetObject("cmdShowFileDetails.Image"), System.Drawing.Image)
        Me.cmdShowFileDetails.Location = New System.Drawing.Point(292, 81)
        Me.cmdShowFileDetails.Name = "cmdShowFileDetails"
        Me.cmdShowFileDetails.Size = New System.Drawing.Size(26, 26)
        Me.cmdShowFileDetails.TabIndex = 21
        Me.cmdShowFileDetails.UseVisualStyleBackColor = True
        '
        'cmdShowFileProperties
        '
        Me.cmdShowFileProperties.Image = CType(resources.GetObject("cmdShowFileProperties.Image"), System.Drawing.Image)
        Me.cmdShowFileProperties.Location = New System.Drawing.Point(318, 81)
        Me.cmdShowFileProperties.Name = "cmdShowFileProperties"
        Me.cmdShowFileProperties.Size = New System.Drawing.Size(26, 26)
        Me.cmdShowFileProperties.TabIndex = 20
        Me.cmdShowFileProperties.UseVisualStyleBackColor = True
        '
        'cmdOpenDirectory
        '
        Me.cmdOpenDirectory.Image = CType(resources.GetObject("cmdOpenDirectory.Image"), System.Drawing.Image)
        Me.cmdOpenDirectory.Location = New System.Drawing.Point(344, 81)
        Me.cmdOpenDirectory.Name = "cmdOpenDirectory"
        Me.cmdOpenDirectory.Size = New System.Drawing.Size(26, 26)
        Me.cmdOpenDirectory.TabIndex = 19
        Me.cmdOpenDirectory.UseVisualStyleBackColor = True
        '
        'txtProcessPath
        '
        Me.txtProcessPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProcessPath.Location = New System.Drawing.Point(84, 82)
        Me.txtProcessPath.Name = "txtProcessPath"
        Me.txtProcessPath.ReadOnly = True
        Me.txtProcessPath.Size = New System.Drawing.Size(202, 22)
        Me.txtProcessPath.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Image path"
        '
        'txtImageVersion
        '
        Me.txtImageVersion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtImageVersion.Location = New System.Drawing.Point(85, 59)
        Me.txtImageVersion.Name = "txtImageVersion"
        Me.txtImageVersion.ReadOnly = True
        Me.txtImageVersion.Size = New System.Drawing.Size(285, 22)
        Me.txtImageVersion.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Image version"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(82, 38)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(77, 13)
        Me.lblCopyright.TabIndex = 14
        Me.lblCopyright.Text = "File copyright"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(82, 19)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(86, 13)
        Me.lblDescription.TabIndex = 13
        Me.lblDescription.Text = "File description"
        '
        'pctSmallIcon
        '
        Me.pctSmallIcon.ContextMenuStrip = Me.menuCopyPctSmall
        Me.pctSmallIcon.Location = New System.Drawing.Point(44, 35)
        Me.pctSmallIcon.Name = "pctSmallIcon"
        Me.pctSmallIcon.Size = New System.Drawing.Size(16, 16)
        Me.pctSmallIcon.TabIndex = 12
        Me.pctSmallIcon.TabStop = False
        '
        'menuCopyPctSmall
        '
        Me.menuCopyPctSmall.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7})
        Me.menuCopyPctSmall.Name = "menuCopyPctbig"
        Me.menuCopyPctSmall.Size = New System.Drawing.Size(170, 26)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = Global.YAPM.My.Resources.Resources.copy16
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem7.Text = "Copy to clipboard"
        '
        'pctBigIcon
        '
        Me.pctBigIcon.ContextMenuStrip = Me.menuCopyPctbig
        Me.pctBigIcon.Location = New System.Drawing.Point(6, 19)
        Me.pctBigIcon.Name = "pctBigIcon"
        Me.pctBigIcon.Size = New System.Drawing.Size(32, 32)
        Me.pctBigIcon.TabIndex = 11
        Me.pctBigIcon.TabStop = False
        '
        'menuCopyPctbig
        '
        Me.menuCopyPctbig.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6})
        Me.menuCopyPctbig.Name = "menuCopyPctbig"
        Me.menuCopyPctbig.Size = New System.Drawing.Size(170, 26)
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = Global.YAPM.My.Resources.Resources.copy16
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem6.Text = "Copy to clipboard"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(636, 258)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Statistics"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblUserObjectsCount)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.lblGDIcount)
        Me.GroupBox5.Controls.Add(Me.lbl789)
        Me.GroupBox5.Controls.Add(Me.lblHandles)
        Me.GroupBox5.Controls.Add(Me.Label53)
        Me.GroupBox5.Location = New System.Drawing.Point(416, 114)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 75)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Other"
        '
        'lblUserObjectsCount
        '
        Me.lblUserObjectsCount.AutoSize = True
        Me.lblUserObjectsCount.Location = New System.Drawing.Point(102, 54)
        Me.lblUserObjectsCount.Name = "lblUserObjectsCount"
        Me.lblUserObjectsCount.Size = New System.Drawing.Size(19, 13)
        Me.lblUserObjectsCount.TabIndex = 5
        Me.lblUserObjectsCount.Text = "00"
        Me.lblUserObjectsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(8, 54)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "User objects"
        '
        'lblGDIcount
        '
        Me.lblGDIcount.AutoSize = True
        Me.lblGDIcount.Location = New System.Drawing.Point(101, 35)
        Me.lblGDIcount.Name = "lblGDIcount"
        Me.lblGDIcount.Size = New System.Drawing.Size(19, 13)
        Me.lblGDIcount.TabIndex = 3
        Me.lblGDIcount.Text = "00"
        Me.lblGDIcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl789
        '
        Me.lbl789.AutoSize = True
        Me.lbl789.Location = New System.Drawing.Point(7, 35)
        Me.lbl789.Name = "lbl789"
        Me.lbl789.Size = New System.Drawing.Size(66, 13)
        Me.lbl789.TabIndex = 2
        Me.lbl789.Text = "GDI objects"
        '
        'lblHandles
        '
        Me.lblHandles.AutoSize = True
        Me.lblHandles.Location = New System.Drawing.Point(100, 16)
        Me.lblHandles.Name = "lblHandles"
        Me.lblHandles.Size = New System.Drawing.Size(19, 13)
        Me.lblHandles.TabIndex = 1
        Me.lblHandles.Text = "00"
        Me.lblHandles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(6, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(49, 13)
        Me.Label53.TabIndex = 0
        Me.Label53.Text = "Handles"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblProcOtherBytes)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.lblProcOther)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.lblProcWriteBytes)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.lblProcWrites)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.lblProcReadBytes)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.lblProcReads)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Location = New System.Drawing.Point(234, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 181)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "I/O"
        '
        'lblProcOtherBytes
        '
        Me.lblProcOtherBytes.AutoSize = True
        Me.lblProcOtherBytes.Location = New System.Drawing.Point(99, 107)
        Me.lblProcOtherBytes.Name = "lblProcOtherBytes"
        Me.lblProcOtherBytes.Size = New System.Drawing.Size(19, 13)
        Me.lblProcOtherBytes.TabIndex = 31
        Me.lblProcOtherBytes.Text = "00"
        Me.lblProcOtherBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 107)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 30
        Me.Label23.Text = "Other bytes"
        '
        'lblProcOther
        '
        Me.lblProcOther.AutoSize = True
        Me.lblProcOther.Location = New System.Drawing.Point(99, 89)
        Me.lblProcOther.Name = "lblProcOther"
        Me.lblProcOther.Size = New System.Drawing.Size(19, 13)
        Me.lblProcOther.TabIndex = 29
        Me.lblProcOther.Text = "00"
        Me.lblProcOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 89)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(37, 13)
        Me.Label30.TabIndex = 28
        Me.Label30.Text = "Other"
        '
        'lblProcWriteBytes
        '
        Me.lblProcWriteBytes.AutoSize = True
        Me.lblProcWriteBytes.Location = New System.Drawing.Point(99, 70)
        Me.lblProcWriteBytes.Name = "lblProcWriteBytes"
        Me.lblProcWriteBytes.Size = New System.Drawing.Size(19, 13)
        Me.lblProcWriteBytes.TabIndex = 27
        Me.lblProcWriteBytes.Text = "00"
        Me.lblProcWriteBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 70)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 13)
        Me.Label36.TabIndex = 26
        Me.Label36.Text = "Write bytes"
        '
        'lblProcWrites
        '
        Me.lblProcWrites.AutoSize = True
        Me.lblProcWrites.Location = New System.Drawing.Point(99, 52)
        Me.lblProcWrites.Name = "lblProcWrites"
        Me.lblProcWrites.Size = New System.Drawing.Size(19, 13)
        Me.lblProcWrites.TabIndex = 25
        Me.lblProcWrites.Text = "00"
        Me.lblProcWrites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 52)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 13)
        Me.Label38.TabIndex = 24
        Me.Label38.Text = "Writes"
        '
        'lblProcReadBytes
        '
        Me.lblProcReadBytes.AutoSize = True
        Me.lblProcReadBytes.Location = New System.Drawing.Point(99, 34)
        Me.lblProcReadBytes.Name = "lblProcReadBytes"
        Me.lblProcReadBytes.Size = New System.Drawing.Size(19, 13)
        Me.lblProcReadBytes.TabIndex = 23
        Me.lblProcReadBytes.Text = "00"
        Me.lblProcReadBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 34)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(63, 13)
        Me.Label40.TabIndex = 22
        Me.Label40.Text = "Read bytes"
        '
        'lblProcReads
        '
        Me.lblProcReads.AutoSize = True
        Me.lblProcReads.Location = New System.Drawing.Point(99, 16)
        Me.lblProcReads.Name = "lblProcReads"
        Me.lblProcReads.Size = New System.Drawing.Size(19, 13)
        Me.lblProcReads.TabIndex = 21
        Me.lblProcReads.Text = "00"
        Me.lblProcReads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 16)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(38, 13)
        Me.Label42.TabIndex = 20
        Me.Label42.Text = "Reads"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblQuotaNPP)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.lblQuotaPNPP)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.lblQuotaPP)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.lblQuotaPPP)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.lblPageFaults)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.lblPeakPageFileUsage)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.lblPageFileUsage)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.lblPeakWorkingSet)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.lblWorkingSet)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 181)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Memory"
        '
        'lblQuotaNPP
        '
        Me.lblQuotaNPP.AutoSize = True
        Me.lblQuotaNPP.Location = New System.Drawing.Point(146, 145)
        Me.lblQuotaNPP.Name = "lblQuotaNPP"
        Me.lblQuotaNPP.Size = New System.Drawing.Size(19, 13)
        Me.lblQuotaNPP.TabIndex = 23
        Me.lblQuotaNPP.Text = "00"
        Me.lblQuotaNPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 145)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(117, 13)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "QuotaNonPagedPool"
        '
        'lblQuotaPNPP
        '
        Me.lblQuotaPNPP.AutoSize = True
        Me.lblQuotaPNPP.Location = New System.Drawing.Point(146, 127)
        Me.lblQuotaPNPP.Name = "lblQuotaPNPP"
        Me.lblQuotaPNPP.Size = New System.Drawing.Size(19, 13)
        Me.lblQuotaPNPP.TabIndex = 21
        Me.lblQuotaPNPP.Text = "00"
        Me.lblQuotaPNPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(5, 127)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(141, 13)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "QuotaPeakNonPagedPool"
        '
        'lblQuotaPP
        '
        Me.lblQuotaPP.AutoSize = True
        Me.lblQuotaPP.Location = New System.Drawing.Point(146, 109)
        Me.lblQuotaPP.Name = "lblQuotaPP"
        Me.lblQuotaPP.Size = New System.Drawing.Size(19, 13)
        Me.lblQuotaPP.TabIndex = 19
        Me.lblQuotaPP.Text = "00"
        Me.lblQuotaPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(5, 109)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(95, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "QuotaPagedPool"
        '
        'lblQuotaPPP
        '
        Me.lblQuotaPPP.AutoSize = True
        Me.lblQuotaPPP.Location = New System.Drawing.Point(146, 91)
        Me.lblQuotaPPP.Name = "lblQuotaPPP"
        Me.lblQuotaPPP.Size = New System.Drawing.Size(19, 13)
        Me.lblQuotaPPP.TabIndex = 17
        Me.lblQuotaPPP.Text = "00"
        Me.lblQuotaPPP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(5, 91)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(119, 13)
        Me.Label32.TabIndex = 16
        Me.Label32.Text = "QuotaPeakPagedPool"
        '
        'lblPageFaults
        '
        Me.lblPageFaults.AutoSize = True
        Me.lblPageFaults.Location = New System.Drawing.Point(146, 163)
        Me.lblPageFaults.Name = "lblPageFaults"
        Me.lblPageFaults.Size = New System.Drawing.Size(19, 13)
        Me.lblPageFaults.TabIndex = 15
        Me.lblPageFaults.Text = "00"
        Me.lblPageFaults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(5, 163)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(64, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Page faults"
        '
        'lblPeakPageFileUsage
        '
        Me.lblPeakPageFileUsage.AutoSize = True
        Me.lblPeakPageFileUsage.Location = New System.Drawing.Point(146, 72)
        Me.lblPeakPageFileUsage.Name = "lblPeakPageFileUsage"
        Me.lblPeakPageFileUsage.Size = New System.Drawing.Size(19, 13)
        Me.lblPeakPageFileUsage.TabIndex = 13
        Me.lblPeakPageFileUsage.Text = "00"
        Me.lblPeakPageFileUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(5, 72)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Peak page file usage"
        '
        'lblPageFileUsage
        '
        Me.lblPageFileUsage.AutoSize = True
        Me.lblPageFileUsage.Location = New System.Drawing.Point(146, 54)
        Me.lblPageFileUsage.Name = "lblPageFileUsage"
        Me.lblPageFileUsage.Size = New System.Drawing.Size(19, 13)
        Me.lblPageFileUsage.TabIndex = 11
        Me.lblPageFileUsage.Text = "00"
        Me.lblPageFileUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(5, 54)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(82, 13)
        Me.Label35.TabIndex = 10
        Me.Label35.Text = "Pagefile usage"
        '
        'lblPeakWorkingSet
        '
        Me.lblPeakWorkingSet.AutoSize = True
        Me.lblPeakWorkingSet.Location = New System.Drawing.Point(146, 36)
        Me.lblPeakWorkingSet.Name = "lblPeakWorkingSet"
        Me.lblPeakWorkingSet.Size = New System.Drawing.Size(19, 13)
        Me.lblPeakWorkingSet.TabIndex = 5
        Me.lblPeakWorkingSet.Text = "00"
        Me.lblPeakWorkingSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(5, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 13)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Peak working set"
        '
        'lblWorkingSet
        '
        Me.lblWorkingSet.AutoSize = True
        Me.lblWorkingSet.Location = New System.Drawing.Point(146, 18)
        Me.lblWorkingSet.Name = "lblWorkingSet"
        Me.lblWorkingSet.Size = New System.Drawing.Size(19, 13)
        Me.lblWorkingSet.TabIndex = 3
        Me.lblWorkingSet.Text = "00"
        Me.lblWorkingSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(5, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "Working set"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTotalTime)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.lblUserTime)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.lblKernelTime)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.lblPriority)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(416, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CPU"
        '
        'lblTotalTime
        '
        Me.lblTotalTime.AutoSize = True
        Me.lblTotalTime.Location = New System.Drawing.Point(100, 73)
        Me.lblTotalTime.Name = "lblTotalTime"
        Me.lblTotalTime.Size = New System.Drawing.Size(70, 13)
        Me.lblTotalTime.TabIndex = 7
        Me.lblTotalTime.Text = "00:00:00.158"
        Me.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 13)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Total time"
        '
        'lblUserTime
        '
        Me.lblUserTime.AutoSize = True
        Me.lblUserTime.Location = New System.Drawing.Point(100, 54)
        Me.lblUserTime.Name = "lblUserTime"
        Me.lblUserTime.Size = New System.Drawing.Size(19, 13)
        Me.lblUserTime.TabIndex = 5
        Me.lblUserTime.Text = "00"
        Me.lblUserTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 54)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "User time"
        '
        'lblKernelTime
        '
        Me.lblKernelTime.AutoSize = True
        Me.lblKernelTime.Location = New System.Drawing.Point(100, 36)
        Me.lblKernelTime.Name = "lblKernelTime"
        Me.lblKernelTime.Size = New System.Drawing.Size(19, 13)
        Me.lblKernelTime.TabIndex = 3
        Me.lblKernelTime.Text = "00"
        Me.lblKernelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Kernel time"
        '
        'lblPriority
        '
        Me.lblPriority.AutoSize = True
        Me.lblPriority.Location = New System.Drawing.Point(100, 16)
        Me.lblPriority.Name = "lblPriority"
        Me.lblPriority.Size = New System.Drawing.Size(19, 13)
        Me.lblPriority.TabIndex = 1
        Me.lblPriority.Text = "00"
        Me.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Priority"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.splitPerformances)
        Me.TabPage3.ImageIndex = 2
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(636, 258)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Performances"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'splitPerformances
        '
        Me.splitPerformances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitPerformances.IsSplitterFixed = True
        Me.splitPerformances.Location = New System.Drawing.Point(3, 3)
        Me.splitPerformances.Name = "splitPerformances"
        Me.splitPerformances.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitPerformances.Panel1
        '
        Me.splitPerformances.Panel1.Controls.Add(Me.graphCPU)
        '
        'splitPerformances.Panel2
        '
        Me.splitPerformances.Panel2.Controls.Add(Me.splitPerformance2)
        Me.splitPerformances.Size = New System.Drawing.Size(630, 252)
        Me.splitPerformances.SplitterDistance = 113
        Me.splitPerformances.SplitterWidth = 1
        Me.splitPerformances.TabIndex = 3
        '
        'graphCPU
        '
        Me.graphCPU.BackColor = System.Drawing.Color.Black
        Me.graphCPU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.graphCPU.EnableGraph = True
        Me.graphCPU.Fixedheight = True
        Me.graphCPU.GridStep = 10
        Me.graphCPU.Location = New System.Drawing.Point(0, 0)
        Me.graphCPU.Name = "graphCPU"
        Me.graphCPU.Size = New System.Drawing.Size(630, 113)
        Me.graphCPU.TabIndex = 1
        Me.graphCPU.TabStop = False
        '
        'splitPerformance2
        '
        Me.splitPerformance2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitPerformance2.IsSplitterFixed = True
        Me.splitPerformance2.Location = New System.Drawing.Point(0, 0)
        Me.splitPerformance2.Name = "splitPerformance2"
        Me.splitPerformance2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitPerformance2.Panel1
        '
        Me.splitPerformance2.Panel1.Controls.Add(Me.graphMemory)
        '
        'splitPerformance2.Panel2
        '
        Me.splitPerformance2.Panel2.Controls.Add(Me.graphIO)
        Me.splitPerformance2.Size = New System.Drawing.Size(630, 138)
        Me.splitPerformance2.SplitterDistance = 58
        Me.splitPerformance2.SplitterWidth = 1
        Me.splitPerformance2.TabIndex = 0
        '
        'graphMemory
        '
        Me.graphMemory.BackColor = System.Drawing.Color.Black
        Me.graphMemory.Color = System.Drawing.Color.Red
        Me.graphMemory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.graphMemory.EnableGraph = True
        Me.graphMemory.Fixedheight = False
        Me.graphMemory.GridStep = 10
        Me.graphMemory.Location = New System.Drawing.Point(0, 0)
        Me.graphMemory.Name = "graphMemory"
        Me.graphMemory.Size = New System.Drawing.Size(630, 58)
        Me.graphMemory.TabIndex = 2
        Me.graphMemory.TabStop = False
        '
        'graphIO
        '
        Me.graphIO.BackColor = System.Drawing.Color.Black
        Me.graphIO.Color = System.Drawing.Color.LimeGreen
        Me.graphIO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.graphIO.EnableGraph = True
        Me.graphIO.Fixedheight = False
        Me.graphIO.GridStep = 10
        Me.graphIO.Location = New System.Drawing.Point(0, 0)
        Me.graphIO.Name = "graphIO"
        Me.graphIO.Size = New System.Drawing.Size(630, 79)
        Me.graphIO.TabIndex = 3
        Me.graphIO.TabStop = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.tabProcessToken)
        Me.TabPage4.ImageIndex = 3
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(636, 258)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Token"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'tabProcessToken
        '
        Me.tabProcessToken.Controls.Add(Me.tabProcessTokenPagePrivileges)
        Me.tabProcessToken.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProcessToken.Location = New System.Drawing.Point(3, 3)
        Me.tabProcessToken.Name = "tabProcessToken"
        Me.tabProcessToken.SelectedIndex = 0
        Me.tabProcessToken.Size = New System.Drawing.Size(630, 252)
        Me.tabProcessToken.TabIndex = 0
        '
        'tabProcessTokenPagePrivileges
        '
        Me.tabProcessTokenPagePrivileges.Controls.Add(Me.lvPrivileges)
        Me.tabProcessTokenPagePrivileges.Location = New System.Drawing.Point(4, 22)
        Me.tabProcessTokenPagePrivileges.Name = "tabProcessTokenPagePrivileges"
        Me.tabProcessTokenPagePrivileges.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProcessTokenPagePrivileges.Size = New System.Drawing.Size(622, 226)
        Me.tabProcessTokenPagePrivileges.TabIndex = 0
        Me.tabProcessTokenPagePrivileges.Text = "Privileges"
        Me.tabProcessTokenPagePrivileges.UseVisualStyleBackColor = True
        '
        'lvPrivileges
        '
        Me.lvPrivileges.AllowColumnReorder = True
        Me.lvPrivileges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader50, Me.ColumnHeader51, Me.ColumnHeader52})
        Me.lvPrivileges.ContextMenuStrip = Me.menuPrivileges
        Me.lvPrivileges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvPrivileges.FullRowSelect = True
        Me.lvPrivileges.HideSelection = False
        Me.lvPrivileges.Location = New System.Drawing.Point(3, 3)
        Me.lvPrivileges.Name = "lvPrivileges"
        Me.lvPrivileges.OverriddenDoubleBuffered = True
        Me.lvPrivileges.Size = New System.Drawing.Size(616, 220)
        Me.lvPrivileges.TabIndex = 4
        Me.lvPrivileges.UseCompatibleStateImageBehavior = False
        Me.lvPrivileges.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader50
        '
        Me.ColumnHeader50.Text = "Name"
        Me.ColumnHeader50.Width = 159
        '
        'ColumnHeader51
        '
        Me.ColumnHeader51.Text = "Status"
        Me.ColumnHeader51.Width = 100
        '
        'ColumnHeader52
        '
        Me.ColumnHeader52.Text = "Description"
        Me.ColumnHeader52.Width = 319
        '
        'menuPrivileges
        '
        Me.menuPrivileges.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem44, Me.DisableToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.menuPrivileges.Name = "mainMenu"
        Me.menuPrivileges.Size = New System.Drawing.Size(118, 70)
        '
        'ToolStripMenuItem44
        '
        Me.ToolStripMenuItem44.Image = Global.YAPM.My.Resources.Resources.ok
        Me.ToolStripMenuItem44.Name = "ToolStripMenuItem44"
        Me.ToolStripMenuItem44.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripMenuItem44.Text = "Enable"
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.Image = Global.YAPM.My.Resources.Resources.close
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.YAPM.My.Resources.Resources.kill
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lvProcMem)
        Me.TabPage5.ImageIndex = 4
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(636, 258)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Memory"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lvProcMem
        '
        Me.lvProcMem.AllowColumnReorder = True
        Me.lvProcMem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader53, Me.ColumnHeader54, Me.ColumnHeader55, Me.ColumnHeader56, Me.ColumnHeader21, Me.ColumnHeader22})
        Me.lvProcMem.ContextMenuStrip = Me.menuProcMem
        Me.lvProcMem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcMem.FullRowSelect = True
        Me.lvProcMem.HideSelection = False
        Me.lvProcMem.Location = New System.Drawing.Point(3, 3)
        Me.lvProcMem.Name = "lvProcMem"
        Me.lvProcMem.OverriddenDoubleBuffered = True
        Me.lvProcMem.Size = New System.Drawing.Size(630, 252)
        Me.lvProcMem.TabIndex = 5
        Me.lvProcMem.UseCompatibleStateImageBehavior = False
        Me.lvProcMem.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader53
        '
        Me.ColumnHeader53.Text = "Name"
        Me.ColumnHeader53.Width = 131
        '
        'ColumnHeader54
        '
        Me.ColumnHeader54.Text = "Address"
        Me.ColumnHeader54.Width = 107
        '
        'ColumnHeader55
        '
        Me.ColumnHeader55.Text = "Size"
        Me.ColumnHeader55.Width = 86
        '
        'ColumnHeader56
        '
        Me.ColumnHeader56.Text = "Protection"
        Me.ColumnHeader56.Width = 91
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "State"
        Me.ColumnHeader21.Width = 73
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Type"
        Me.ColumnHeader22.Width = 100
        '
        'menuProcMem
        '
        Me.menuProcMem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem49, Me.JumpToPEBAddressToolStripMenuItem})
        Me.menuProcMem.Name = "menuProc"
        Me.menuProcMem.Size = New System.Drawing.Size(184, 48)
        '
        'ToolStripMenuItem49
        '
        Me.ToolStripMenuItem49.Image = Global.YAPM.My.Resources.Resources.magnify16
        Me.ToolStripMenuItem49.Name = "ToolStripMenuItem49"
        Me.ToolStripMenuItem49.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem49.Text = "View memory"
        '
        'JumpToPEBAddressToolStripMenuItem
        '
        Me.JumpToPEBAddressToolStripMenuItem.Name = "JumpToPEBAddressToolStripMenuItem"
        Me.JumpToPEBAddressToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.JumpToPEBAddressToolStripMenuItem.Text = "Jump to PEB address"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.SplitContainerInfoProcess)
        Me.TabPage6.ImageIndex = 5
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(636, 258)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Informations"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'SplitContainerInfoProcess
        '
        Me.SplitContainerInfoProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerInfoProcess.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerInfoProcess.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerInfoProcess.Name = "SplitContainerInfoProcess"
        Me.SplitContainerInfoProcess.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerInfoProcess.Panel1
        '
        Me.SplitContainerInfoProcess.Panel1.Controls.Add(Me.chkDisplayNAProcess)
        Me.SplitContainerInfoProcess.Panel1.Controls.Add(Me.chkHandles)
        Me.SplitContainerInfoProcess.Panel1.Controls.Add(Me.chkOnline)
        Me.SplitContainerInfoProcess.Panel1.Controls.Add(Me.chkModules)
        Me.SplitContainerInfoProcess.Panel1.Controls.Add(Me.cmdInfosToClipB)
        '
        'SplitContainerInfoProcess.Panel2
        '
        Me.SplitContainerInfoProcess.Panel2.Controls.Add(Me.rtb)
        Me.SplitContainerInfoProcess.Size = New System.Drawing.Size(630, 252)
        Me.SplitContainerInfoProcess.SplitterDistance = 25
        Me.SplitContainerInfoProcess.TabIndex = 0
        '
        'chkDisplayNAProcess
        '
        Me.chkDisplayNAProcess.AutoSize = True
        Me.chkDisplayNAProcess.Checked = True
        Me.chkDisplayNAProcess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDisplayNAProcess.Location = New System.Drawing.Point(420, 6)
        Me.chkDisplayNAProcess.Name = "chkDisplayNAProcess"
        Me.chkDisplayNAProcess.Size = New System.Drawing.Size(131, 17)
        Me.chkDisplayNAProcess.TabIndex = 18
        Me.chkDisplayNAProcess.Text = "Display all processes"
        Me.chkDisplayNAProcess.UseVisualStyleBackColor = True
        Me.chkDisplayNAProcess.Visible = False
        '
        'chkHandles
        '
        Me.chkHandles.AutoSize = True
        Me.chkHandles.Location = New System.Drawing.Point(350, 6)
        Me.chkHandles.Name = "chkHandles"
        Me.chkHandles.Size = New System.Drawing.Size(68, 17)
        Me.chkHandles.TabIndex = 17
        Me.chkHandles.Text = "Handles"
        Me.chkHandles.UseVisualStyleBackColor = True
        '
        'chkOnline
        '
        Me.chkOnline.AutoSize = True
        Me.chkOnline.Location = New System.Drawing.Point(262, 6)
        Me.chkOnline.Name = "chkOnline"
        Me.chkOnline.Size = New System.Drawing.Size(90, 17)
        Me.chkOnline.TabIndex = 16
        Me.chkOnline.Text = "Online infos"
        Me.chkOnline.UseVisualStyleBackColor = True
        '
        'chkModules
        '
        Me.chkModules.AutoSize = True
        Me.chkModules.Location = New System.Drawing.Point(108, 6)
        Me.chkModules.Name = "chkModules"
        Me.chkModules.Size = New System.Drawing.Size(155, 17)
        Me.chkModules.TabIndex = 15
        Me.chkModules.Text = "Retrive modules/trhreads"
        Me.chkModules.UseVisualStyleBackColor = True
        '
        'cmdInfosToClipB
        '
        Me.cmdInfosToClipB.Enabled = False
        Me.cmdInfosToClipB.Location = New System.Drawing.Point(3, 1)
        Me.cmdInfosToClipB.Name = "cmdInfosToClipB"
        Me.cmdInfosToClipB.Size = New System.Drawing.Size(99, 21)
        Me.cmdInfosToClipB.TabIndex = 14
        Me.cmdInfosToClipB.Text = "Copy to clipboard"
        Me.cmdInfosToClipB.UseVisualStyleBackColor = True
        '
        'rtb
        '
        Me.rtb.AutoWordSelection = True
        Me.rtb.BackColor = System.Drawing.Color.White
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.HideSelection = False
        Me.rtb.Location = New System.Drawing.Point(0, 0)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.Size = New System.Drawing.Size(630, 223)
        Me.rtb.TabIndex = 14
        Me.rtb.Text = ""
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.lvProcServices)
        Me.TabPage7.ImageIndex = 7
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(636, 258)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Services"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'lvProcServices
        '
        Me.lvProcServices.AllowColumnReorder = True
        Me.lvProcServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader23, Me.ColumnHeader47, Me.ColumnHeader48, Me.ColumnHeader20})
        Me.lvProcServices.ContextMenuStrip = Me.menuProcServ
        Me.lvProcServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcServices.FullRowSelect = True
        Me.lvProcServices.HideSelection = False
        Me.lvProcServices.Location = New System.Drawing.Point(3, 3)
        Me.lvProcServices.Name = "lvProcServices"
        Me.lvProcServices.OverriddenDoubleBuffered = True
        Me.lvProcServices.Size = New System.Drawing.Size(630, 252)
        Me.lvProcServices.TabIndex = 5
        Me.lvProcServices.UseCompatibleStateImageBehavior = False
        Me.lvProcServices.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "ServiceName"
        Me.ColumnHeader23.Width = 158
        '
        'ColumnHeader47
        '
        Me.ColumnHeader47.Text = "State"
        Me.ColumnHeader47.Width = 98
        '
        'ColumnHeader48
        '
        Me.ColumnHeader48.Text = "CommonName"
        Me.ColumnHeader48.Width = 246
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Path"
        Me.ColumnHeader20.Width = 330
        '
        'menuProcServ
        '
        Me.menuProcServ.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem43})
        Me.menuProcServ.Name = "menuProc"
        Me.menuProcServ.Size = New System.Drawing.Size(145, 26)
        '
        'ToolStripMenuItem43
        '
        Me.ToolStripMenuItem43.Image = Global.YAPM.My.Resources.Resources.exe
        Me.ToolStripMenuItem43.Name = "ToolStripMenuItem43"
        Me.ToolStripMenuItem43.Size = New System.Drawing.Size(144, 22)
        Me.ToolStripMenuItem43.Text = "Select service"
        '
        'tabNetwork
        '
        Me.tabNetwork.Controls.Add(Me.lvProcNetwork)
        Me.tabNetwork.ImageIndex = 8
        Me.tabNetwork.Location = New System.Drawing.Point(4, 22)
        Me.tabNetwork.Name = "tabNetwork"
        Me.tabNetwork.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNetwork.Size = New System.Drawing.Size(636, 258)
        Me.tabNetwork.TabIndex = 7
        Me.tabNetwork.Text = "Network"
        Me.tabNetwork.UseVisualStyleBackColor = True
        '
        'lvProcNetwork
        '
        Me.lvProcNetwork.AllowColumnReorder = True
        Me.lvProcNetwork.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader49, Me.ColumnHeader57, Me.ColumnHeader58, Me.ColumnHeader59})
        Me.lvProcNetwork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcNetwork.FullRowSelect = True
        Me.lvProcNetwork.HideSelection = False
        Me.lvProcNetwork.Location = New System.Drawing.Point(3, 3)
        Me.lvProcNetwork.Name = "lvProcNetwork"
        Me.lvProcNetwork.OverriddenDoubleBuffered = True
        Me.lvProcNetwork.Size = New System.Drawing.Size(630, 252)
        Me.lvProcNetwork.TabIndex = 5
        Me.lvProcNetwork.UseCompatibleStateImageBehavior = False
        Me.lvProcNetwork.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader49
        '
        Me.ColumnHeader49.Text = "Local"
        Me.ColumnHeader49.Width = 210
        '
        'ColumnHeader57
        '
        Me.ColumnHeader57.Text = "Port"
        Me.ColumnHeader57.Width = 100
        '
        'ColumnHeader58
        '
        Me.ColumnHeader58.Text = "Protocol"
        Me.ColumnHeader58.Width = 100
        '
        'ColumnHeader59
        '
        Me.ColumnHeader59.Text = "State"
        Me.ColumnHeader59.Width = 150
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.SplitContainerStrings)
        Me.TabPage8.ImageKey = "font"
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(636, 258)
        Me.TabPage8.TabIndex = 8
        Me.TabPage8.Text = "Strings"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'SplitContainerStrings
        '
        Me.SplitContainerStrings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerStrings.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerStrings.Name = "SplitContainerStrings"
        Me.SplitContainerStrings.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerStrings.Panel1
        '
        Me.SplitContainerStrings.Panel1.Controls.Add(Me.lvProcString)
        '
        'SplitContainerStrings.Panel2
        '
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.cmdProcSearchR)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.cmdProcSearchL)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.pgbString)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.Label28)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.txtSearchProcString)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.cmdProcStringSave)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.optProcStringMemory)
        Me.SplitContainerStrings.Panel2.Controls.Add(Me.optProcStringImage)
        Me.SplitContainerStrings.Size = New System.Drawing.Size(636, 258)
        Me.SplitContainerStrings.SplitterDistance = 218
        Me.SplitContainerStrings.TabIndex = 0
        '
        'lvProcString
        '
        Me.lvProcString.AllowColumnReorder = True
        Me.lvProcString.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader76, Me.ColumnHeader77})
        Me.lvProcString.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcString.FullRowSelect = True
        ListViewGroup1.Header = "Strings"
        ListViewGroup1.Name = "gpOther"
        ListViewGroup2.Header = "Search result"
        ListViewGroup2.Name = "gpSearch"
        Me.lvProcString.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.lvProcString.HideSelection = False
        Me.lvProcString.Location = New System.Drawing.Point(0, 0)
        Me.lvProcString.MultiSelect = False
        Me.lvProcString.Name = "lvProcString"
        Me.lvProcString.OverriddenDoubleBuffered = True
        Me.lvProcString.Size = New System.Drawing.Size(636, 218)
        Me.lvProcString.TabIndex = 4
        Me.lvProcString.UseCompatibleStateImageBehavior = False
        Me.lvProcString.View = System.Windows.Forms.View.Details
        Me.lvProcString.VirtualMode = True
        '
        'ColumnHeader76
        '
        Me.ColumnHeader76.Text = "Position"
        Me.ColumnHeader76.Width = 149
        '
        'ColumnHeader77
        '
        Me.ColumnHeader77.Text = "String"
        Me.ColumnHeader77.Width = 447
        '
        'cmdProcSearchR
        '
        Me.cmdProcSearchR.Location = New System.Drawing.Point(499, 1)
        Me.cmdProcSearchR.Name = "cmdProcSearchR"
        Me.cmdProcSearchR.Size = New System.Drawing.Size(17, 23)
        Me.cmdProcSearchR.TabIndex = 19
        Me.cmdProcSearchR.Text = ">"
        Me.cmdProcSearchR.UseVisualStyleBackColor = True
        '
        'cmdProcSearchL
        '
        Me.cmdProcSearchL.Location = New System.Drawing.Point(476, 1)
        Me.cmdProcSearchL.Name = "cmdProcSearchL"
        Me.cmdProcSearchL.Size = New System.Drawing.Size(17, 23)
        Me.cmdProcSearchL.TabIndex = 18
        Me.cmdProcSearchL.Text = "<"
        Me.cmdProcSearchL.UseVisualStyleBackColor = True
        '
        'pgbString
        '
        Me.pgbString.Location = New System.Drawing.Point(230, 1)
        Me.pgbString.Name = "pgbString"
        Me.pgbString.Size = New System.Drawing.Size(120, 23)
        Me.pgbString.TabIndex = 17
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(365, 6)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "Search"
        '
        'txtSearchProcString
        '
        Me.txtSearchProcString.Location = New System.Drawing.Point(410, 2)
        Me.txtSearchProcString.Name = "txtSearchProcString"
        Me.txtSearchProcString.Size = New System.Drawing.Size(60, 22)
        Me.txtSearchProcString.TabIndex = 14
        '
        'cmdProcStringSave
        '
        Me.cmdProcStringSave.Location = New System.Drawing.Point(140, 1)
        Me.cmdProcStringSave.Name = "cmdProcStringSave"
        Me.cmdProcStringSave.Size = New System.Drawing.Size(70, 23)
        Me.cmdProcStringSave.TabIndex = 2
        Me.cmdProcStringSave.Text = "Save..."
        Me.cmdProcStringSave.UseVisualStyleBackColor = True
        '
        'optProcStringMemory
        '
        Me.optProcStringMemory.AutoSize = True
        Me.optProcStringMemory.Location = New System.Drawing.Point(63, 4)
        Me.optProcStringMemory.Name = "optProcStringMemory"
        Me.optProcStringMemory.Size = New System.Drawing.Size(66, 17)
        Me.optProcStringMemory.TabIndex = 1
        Me.optProcStringMemory.Text = "Memory"
        Me.optProcStringMemory.UseVisualStyleBackColor = True
        '
        'optProcStringImage
        '
        Me.optProcStringImage.AutoSize = True
        Me.optProcStringImage.Checked = True
        Me.optProcStringImage.Location = New System.Drawing.Point(3, 4)
        Me.optProcStringImage.Name = "optProcStringImage"
        Me.optProcStringImage.Size = New System.Drawing.Size(56, 17)
        Me.optProcStringImage.TabIndex = 0
        Me.optProcStringImage.TabStop = True
        Me.optProcStringImage.Text = "Image"
        Me.optProcStringImage.UseVisualStyleBackColor = True
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.lvProcEnv)
        Me.TabPage9.ImageIndex = 10
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(636, 258)
        Me.TabPage9.TabIndex = 9
        Me.TabPage9.Text = "Environment"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'lvProcEnv
        '
        Me.lvProcEnv.AllowColumnReorder = True
        Me.lvProcEnv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader60, Me.ColumnHeader61})
        Me.lvProcEnv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvProcEnv.FullRowSelect = True
        ListViewGroup3.Header = "Strings"
        ListViewGroup3.Name = "gpOther"
        ListViewGroup4.Header = "Search result"
        ListViewGroup4.Name = "gpSearch"
        Me.lvProcEnv.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup3, ListViewGroup4})
        Me.lvProcEnv.HideSelection = False
        Me.lvProcEnv.Location = New System.Drawing.Point(0, 0)
        Me.lvProcEnv.Name = "lvProcEnv"
        Me.lvProcEnv.OverriddenDoubleBuffered = True
        Me.lvProcEnv.Size = New System.Drawing.Size(636, 258)
        Me.lvProcEnv.TabIndex = 5
        Me.lvProcEnv.UseCompatibleStateImageBehavior = False
        Me.lvProcEnv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader60
        '
        Me.ColumnHeader60.Text = "Variable"
        Me.ColumnHeader60.Width = 169
        '
        'ColumnHeader61
        '
        Me.ColumnHeader61.Text = "Value"
        Me.ColumnHeader61.Width = 431
        '
        'timerProcPerf
        '
        Me.timerProcPerf.Enabled = True
        Me.timerProcPerf.Interval = 1000
        '
        'imgMain
        '
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMain.Images.SetKeyName(0, "main_big2.ico")
        Me.imgMain.Images.SetKeyName(1, "noicon32")
        '
        'imgProcess
        '
        Me.imgProcess.ImageStream = CType(resources.GetObject("imgProcess.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgProcess.TransparentColor = System.Drawing.Color.Transparent
        Me.imgProcess.Images.SetKeyName(0, "noIcon")
        '
        'frmProcessInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 284)
        Me.Controls.Add(Me.tabProcess)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(630, 320)
        Me.Name = "frmProcessInfo"
        Me.Text = "Process informations"
        Me.tabProcess.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpProcGeneralFile.ResumeLayout(False)
        Me.gpProcGeneralFile.PerformLayout()
        CType(Me.pctSmallIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCopyPctSmall.ResumeLayout(False)
        CType(Me.pctBigIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCopyPctbig.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.splitPerformances.Panel1.ResumeLayout(False)
        Me.splitPerformances.Panel2.ResumeLayout(False)
        Me.splitPerformances.ResumeLayout(False)
        CType(Me.graphCPU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitPerformance2.Panel1.ResumeLayout(False)
        Me.splitPerformance2.Panel2.ResumeLayout(False)
        Me.splitPerformance2.ResumeLayout(False)
        CType(Me.graphMemory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graphIO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.tabProcessToken.ResumeLayout(False)
        Me.tabProcessTokenPagePrivileges.ResumeLayout(False)
        Me.menuPrivileges.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.menuProcMem.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.SplitContainerInfoProcess.Panel1.ResumeLayout(False)
        Me.SplitContainerInfoProcess.Panel1.PerformLayout()
        Me.SplitContainerInfoProcess.Panel2.ResumeLayout(False)
        Me.SplitContainerInfoProcess.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.menuProcServ.ResumeLayout(False)
        Me.tabNetwork.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.SplitContainerStrings.Panel1.ResumeLayout(False)
        Me.SplitContainerStrings.Panel2.ResumeLayout(False)
        Me.SplitContainerStrings.Panel2.PerformLayout()
        Me.SplitContainerStrings.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabProcess As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProcessUser As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProcessId As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtProcessStarted As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtParentProcess As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gpProcGeneralFile As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShowFileDetails As System.Windows.Forms.Button
    Friend WithEvents cmdShowFileProperties As System.Windows.Forms.Button
    Friend WithEvents cmdOpenDirectory As System.Windows.Forms.Button
    Friend WithEvents txtProcessPath As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtImageVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents pctSmallIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pctBigIcon As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUserObjectsCount As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblGDIcount As System.Windows.Forms.Label
    Friend WithEvents lbl789 As System.Windows.Forms.Label
    Friend WithEvents lblHandles As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcOtherBytes As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblProcOther As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblProcWriteBytes As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblProcWrites As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblProcReadBytes As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblProcReads As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblQuotaNPP As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblQuotaPNPP As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblQuotaPP As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblQuotaPPP As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblPageFaults As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblPeakPageFileUsage As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblPageFileUsage As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblPeakWorkingSet As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblWorkingSet As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalTime As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblUserTime As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblKernelTime As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblPriority As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents splitPerformances As System.Windows.Forms.SplitContainer
    Friend WithEvents graphCPU As YAPM.Graph2
    Friend WithEvents splitPerformance2 As System.Windows.Forms.SplitContainer
    Friend WithEvents graphMemory As YAPM.Graph2
    Friend WithEvents graphIO As YAPM.Graph2
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents tabProcessToken As System.Windows.Forms.TabControl
    Friend WithEvents tabProcessTokenPagePrivileges As System.Windows.Forms.TabPage
    Friend WithEvents lvPrivileges As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader50 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader51 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader52 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents lvProcMem As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader53 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader54 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader55 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader56 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerInfoProcess As System.Windows.Forms.SplitContainer
    Friend WithEvents chkDisplayNAProcess As System.Windows.Forms.CheckBox
    Friend WithEvents chkHandles As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnline As System.Windows.Forms.CheckBox
    Friend WithEvents chkModules As System.Windows.Forms.CheckBox
    Friend WithEvents cmdInfosToClipB As System.Windows.Forms.Button
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents lvProcServices As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader47 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader48 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabNetwork As System.Windows.Forms.TabPage
    Friend WithEvents lvProcNetwork As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader49 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader57 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader58 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader59 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerStrings As System.Windows.Forms.SplitContainer
    Friend WithEvents lvProcString As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader76 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader77 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdProcSearchR As System.Windows.Forms.Button
    Friend WithEvents cmdProcSearchL As System.Windows.Forms.Button
    Friend WithEvents pgbString As System.Windows.Forms.ProgressBar
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSearchProcString As System.Windows.Forms.TextBox
    Friend WithEvents cmdProcStringSave As System.Windows.Forms.Button
    Friend WithEvents optProcStringMemory As System.Windows.Forms.RadioButton
    Friend WithEvents optProcStringImage As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents lvProcEnv As YAPM.DoubleBufferedLV
    Friend WithEvents ColumnHeader60 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader61 As System.Windows.Forms.ColumnHeader
    Friend WithEvents menuProcServ As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem43 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCopyPctbig As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCopyPctSmall As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPrivileges As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem44 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcMem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem49 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JumpToPEBAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerProcPerf As System.Windows.Forms.Timer
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents imgProcess As System.Windows.Forms.ImageList
End Class