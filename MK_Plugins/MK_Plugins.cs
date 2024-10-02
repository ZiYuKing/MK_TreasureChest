using PKHeX.Core;

namespace MK_Plugins;

public abstract class MK_Plugins : IPlugin
{
    private const string ParentMenuName = "Menu_MKPulgins";
    private const string ParentMenuText = "MKPulgins";
    private const string ParentMenuParent = "Menu_Tools";
    public abstract string Name { get; }
    public abstract int Priority { get; }
    public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
    public IPKMView PKMEditor { get; private set; } = null!;
    public void Initialize(params object[] args)
    {
        SaveFileEditor = (ISaveFileProvider)(
                Array.Find(args, z => z is ISaveFileProvider)
                ?? throw new Exception("没有实现ISaveFileProvider接口的对象")
            );
        PKMEditor = (IPKMView)(
                Array.Find(args, z => z is IPKMView) ?? throw new Exception("没有实现IPKMView接口的对象")
            );
        var menu = (ToolStrip)(
                Array.Find(args, z => z is ToolStrip) ?? throw new Exception("没有实现ToolStrip接口的对象")
            );
        LoadMenuStrip(menu);
    }
    private void LoadMenuStrip(ToolStrip menuStrip)
    {
        var items = menuStrip.Items;
        if (items.Find(ParentMenuParent, false)[0] is not ToolStripDropDownItem tools)
            return;
        var toolsitems = tools.DropDownItems;
        var modmenusearch = toolsitems.Find(ParentMenuName, false);
        var modmenu = GetModMenu(tools, modmenusearch);
        AddPluginControl(modmenu);
    }
    private static ToolStripMenuItem GetModMenu(ToolStripDropDownItem tools, IReadOnlyList<ToolStripItem> search)
    {
        if (search.Count != 0)
            return (ToolStripMenuItem)search[0];

        var modmenu = CreateBaseGroupItem();
        tools.DropDownItems.Insert(0, modmenu);
        return modmenu;
    }
    private static ToolStripMenuItem CreateBaseGroupItem() => new(ParentMenuText) { Image = Properties.Resource.Z_K, Name = ParentMenuName, };
    protected abstract void AddPluginControl(ToolStripDropDownItem modmenu);
    public virtual void NotifySaveLoaded()
    {
        Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
    }
    public virtual bool TryLoadFile(string filePath)
    {
        Console.WriteLine(
            $"{Name} was provided with the file path, but chose to do nothing with it."
        );
        return false; // no action taken
    }
}
