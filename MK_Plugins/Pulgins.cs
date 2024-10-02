using MK_Plugins.PulginsGUI;

namespace MK_Plugins;
//public启用，internal禁用
public class MK_SwitchController : MK_Plugins
{
    public override string Name => "模拟手柄";
    public override int Priority => 0;
    protected override void AddPluginControl(ToolStripDropDownItem modmenu)
    {
        var ctrl = new ToolStripMenuItem(Name){ Image = Properties.Resource._switch };
        ctrl.Click += OpenForm;
        ctrl.Name = "模拟手柄";
        modmenu.DropDownItems.Add(ctrl);
    }
    private void OpenForm(object? sender, EventArgs e)
    {
        if (sender == null)
            return;
        var form = new MK_SwitchControllerForm();
        form.Show();
    }
}
public class MK_TradePartnerViewer : MK_Plugins
{
    public override string Name => "交易对象查询器";
    public override int Priority => 1;
    protected override void AddPluginControl(ToolStripDropDownItem modmenu)
    {
        var ctrl = new ToolStripMenuItem(Name) { Image = Properties.Resource.Trade };
        ctrl.Click += OpenForm;
        ctrl.Name = "交易对象查询器";
        modmenu.DropDownItems.Add(ctrl);
    }
    private void OpenForm(object? sender, EventArgs e)
    {
        if (sender == null)
            return;
        var form = new MK_TradePartnerViewerForm(SaveFileEditor, PKMEditor);
        form.Show();
    }
}

public class MK_SemiAutoTrade : MK_Plugins
{
    public override string Name => "半自动交易器";
    public override int Priority => 2;
    protected override void AddPluginControl(ToolStripDropDownItem modmenu)
    {
        var ctrl = new ToolStripMenuItem(Name) { Image = Properties.Resource.PokémonCenter };
        ctrl.Click += OpenForm;
        ctrl.Name = "半自动交易器";
        modmenu.DropDownItems.Add(ctrl);
    }
    private void OpenForm(object? sender, EventArgs e)
    {
        if (sender == null)
            return;
        var form = new MK_SemiAutoTradeForm(SaveFileEditor, PKMEditor);
        form.Show();
    }
}

public class GenerateMoveIndex : MK_Plugins
{
    public override string Name => "PS网页字典生成器";
    public override int Priority => 3;
    protected override void AddPluginControl(ToolStripDropDownItem modmenu)
    {
        var ctrl = new ToolStripMenuItem(Name) { Image = Properties.Resource.PS };
        ctrl.Click += OpenForm;
        ctrl.Name = "PS网页字典生成器";
        modmenu.DropDownItems.Add(ctrl);
    }
    private void OpenForm(object? sender, EventArgs e)
    {
        if (sender == null)
            return;
        var form = new MK_GenerateMoveIndexForm(SaveFileEditor, PKMEditor);
        form.Show();
    }
}