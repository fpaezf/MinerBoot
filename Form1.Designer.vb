<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.CheckTemperaturesTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartMiningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopMiningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GamingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WatchDogMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitHubPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonateWithPayPalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMinerBootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WatchDog = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearEventsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CPUName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.IPLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GPUMaxTempLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.UpdateIPLabel = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckTemperaturesTimer
        '
        Me.CheckTemperaturesTimer.Enabled = True
        Me.CheckTemperaturesTimer.Interval = 3000
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(395, 277)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 16
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Device name"
        Me.ColumnHeader1.Width = 293
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Temp. (°C)"
        Me.ColumnHeader3.Width = 68
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "nvidia.ico")
        Me.ImageList1.Images.SetKeyName(1, "amd.ico")
        Me.ImageList1.Images.SetKeyName(2, "1491062350_hardware.ico")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ModeToolStripMenuItem, Me.WatchDogMenu, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(419, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ApplicationToolStripMenuItem
        '
        Me.ApplicationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartMiningToolStripMenuItem, Me.StopMiningToolStripMenuItem, Me.ToolStripSeparator1, Me.AlwaysOnTopToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.ApplicationToolStripMenuItem.Image = CType(resources.GetObject("ApplicationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ApplicationToolStripMenuItem.Name = "ApplicationToolStripMenuItem"
        Me.ApplicationToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ApplicationToolStripMenuItem.Text = "&Application"
        '
        'StartMiningToolStripMenuItem
        '
        Me.StartMiningToolStripMenuItem.Image = CType(resources.GetObject("StartMiningToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartMiningToolStripMenuItem.Name = "StartMiningToolStripMenuItem"
        Me.StartMiningToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.StartMiningToolStripMenuItem.Text = "&Start Mining"
        '
        'StopMiningToolStripMenuItem
        '
        Me.StopMiningToolStripMenuItem.Image = CType(resources.GetObject("StopMiningToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StopMiningToolStripMenuItem.Name = "StopMiningToolStripMenuItem"
        Me.StopMiningToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.StopMiningToolStripMenuItem.Text = "&Stop mining"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.Checked = True
        Me.AlwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AlwaysOnTopToolStripMenuItem.Image = CType(resources.GetObject("AlwaysOnTopToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AlwaysOnTopToolStripMenuItem.Text = "&Always on top"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ModeToolStripMenuItem
        '
        Me.ModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MiningToolStripMenuItem, Me.GamingToolStripMenuItem})
        Me.ModeToolStripMenuItem.Image = CType(resources.GetObject("ModeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ModeToolStripMenuItem.Name = "ModeToolStripMenuItem"
        Me.ModeToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ModeToolStripMenuItem.Text = "&Mode"
        '
        'MiningToolStripMenuItem
        '
        Me.MiningToolStripMenuItem.Checked = True
        Me.MiningToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MiningToolStripMenuItem.Image = CType(resources.GetObject("MiningToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MiningToolStripMenuItem.Name = "MiningToolStripMenuItem"
        Me.MiningToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MiningToolStripMenuItem.Text = "&Mining"
        '
        'GamingToolStripMenuItem
        '
        Me.GamingToolStripMenuItem.Image = CType(resources.GetObject("GamingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GamingToolStripMenuItem.Name = "GamingToolStripMenuItem"
        Me.GamingToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GamingToolStripMenuItem.Text = "&Gaming"
        '
        'WatchDogMenu
        '
        Me.WatchDogMenu.Image = CType(resources.GetObject("WatchDogMenu.Image"), System.Drawing.Image)
        Me.WatchDogMenu.Name = "WatchDogMenu"
        Me.WatchDogMenu.Size = New System.Drawing.Size(56, 20)
        Me.WatchDogMenu.Text = "OFF"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GitHubPageToolStripMenuItem, Me.DonateWithPayPalToolStripMenuItem, Me.AboutMinerBootToolStripMenuItem})
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'GitHubPageToolStripMenuItem
        '
        Me.GitHubPageToolStripMenuItem.Image = CType(resources.GetObject("GitHubPageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GitHubPageToolStripMenuItem.Name = "GitHubPageToolStripMenuItem"
        Me.GitHubPageToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GitHubPageToolStripMenuItem.Text = "&GitHub page"
        '
        'DonateWithPayPalToolStripMenuItem
        '
        Me.DonateWithPayPalToolStripMenuItem.Image = CType(resources.GetObject("DonateWithPayPalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DonateWithPayPalToolStripMenuItem.Name = "DonateWithPayPalToolStripMenuItem"
        Me.DonateWithPayPalToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DonateWithPayPalToolStripMenuItem.Text = "&Donate with PayPal"
        '
        'AboutMinerBootToolStripMenuItem
        '
        Me.AboutMinerBootToolStripMenuItem.Image = CType(resources.GetObject("AboutMinerBootToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutMinerBootToolStripMenuItem.Name = "AboutMinerBootToolStripMenuItem"
        Me.AboutMinerBootToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutMinerBootToolStripMenuItem.Text = "&About MinerBoot"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "MinerBoot"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreToolStripMenuItem, Me.ToolStripSeparator3, Me.QuitToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(114, 54)
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Image = CType(resources.GetObject("RestoreToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "&Restore"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(110, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Image = CType(resources.GetObject("QuitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'WatchDog
        '
        Me.WatchDog.Interval = 3000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 400
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Control description"
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.ListView2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.HideSelection = False
        Me.ListView2.LargeImageList = Me.ImageList2
        Me.ListView2.Location = New System.Drawing.Point(3, 3)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(395, 277)
        Me.ListView2.SmallImageList = Me.ImageList2
        Me.ListView2.TabIndex = 19
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Timestamp & Event description"
        Me.ColumnHeader2.Width = 355
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearEventsListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 26)
        '
        'ClearEventsListToolStripMenuItem
        '
        Me.ClearEventsListToolStripMenuItem.Image = CType(resources.GetObject("ClearEventsListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClearEventsListToolStripMenuItem.Name = "ClearEventsListToolStripMenuItem"
        Me.ClearEventsListToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ClearEventsListToolStripMenuItem.Text = "&Clear events list"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "tick (2).ico")
        Me.ImageList2.Images.SetKeyName(1, "cross (2).ico")
        Me.ImageList2.Images.SetKeyName(2, "warning.ico")
        Me.ImageList2.Images.SetKeyName(3, "1491062350_hardware.ico")
        Me.ImageList2.Images.SetKeyName(4, "application_view_list (3).ico")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CPUName, Me.ToolStripStatusLabel2, Me.IPLabel, Me.ToolStripStatusLabel1, Me.GPUMaxTempLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 410)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(419, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CPUName
        '
        Me.CPUName.Image = CType(resources.GetObject("CPUName.Image"), System.Drawing.Image)
        Me.CPUName.Name = "CPUName"
        Me.CPUName.Size = New System.Drawing.Size(83, 17)
        Me.CPUName.Text = "CPU NAME"
        Me.CPUName.ToolTipText = "This is your CPU brand and model"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel2.Text = "   "
        '
        'IPLabel
        '
        Me.IPLabel.Image = CType(resources.GetObject("IPLabel.Image"), System.Drawing.Image)
        Me.IPLabel.IsLink = True
        Me.IPLabel.Name = "IPLabel"
        Me.IPLabel.Size = New System.Drawing.Size(104, 17)
        Me.IPLabel.Text = "000.000.000.000"
        Me.IPLabel.ToolTipText = "This is your public IP address. ¡Click to copy!"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(89, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "   "
        '
        'GPUMaxTempLabel
        '
        Me.GPUMaxTempLabel.Image = CType(resources.GetObject("GPUMaxTempLabel.Image"), System.Drawing.Image)
        Me.GPUMaxTempLabel.Name = "GPUMaxTempLabel"
        Me.GPUMaxTempLabel.Size = New System.Drawing.Size(112, 17)
        Me.GPUMaxTempLabel.Text = "GPU_MAX_TEMP"
        Me.GPUMaxTempLabel.ToolTipText = "This is the maximum temperature allowed for your GPUs"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ImageList = Me.ImageList2
        Me.TabControl1.Location = New System.Drawing.Point(6, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(408, 310)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.ImageIndex = 3
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(400, 283)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "GPU Devices"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.ImageIndex = 4
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(400, 283)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Application Events"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'UpdateIPLabel
        '
        Me.UpdateIPLabel.Enabled = True
        Me.UpdateIPLabel.Interval = 60000
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 63)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Miner info"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Looking for miner process..."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(165, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "(...)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Miner is running?:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Miner executable:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 432)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(435, 325)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MinerBoot v0.9 (BETA)"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckTemperaturesTimer As Timer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartMiningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StopMiningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlwaysOnTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WatchDog As Timer
    Friend WithEvents GitHubPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DonateWithPayPalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutMinerBootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents WatchDogMenu As ToolStripMenuItem
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents CPUName As ToolStripStatusLabel
    Friend WithEvents GPUMaxTempLabel As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents IPLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ClearEventsListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateIPLabel As Timer
    Friend WithEvents ModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GamingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
End Class
