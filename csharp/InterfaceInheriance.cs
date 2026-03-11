using static System.Console;

var ft = new FeatureToggle();
var fts = new FeatureToggleSnapshot();

WriteLine($"Ft {ft.GetFor("ft")}");
WriteLine($"Fts {fts.GetFor("ft")}");

interface IFeatureToggle
{
    bool IsEnabled { get; }
    string GetFor(string key);
    string GetAll();
}
interface IFeatureToggleSnapshot : IFeatureToggle
{

}

class FeatureToggleSnapshot : IFeatureToggleSnapshot
{
    public bool IsEnabled { get; set; }
    public virtual string GetFor(string key) {
        return key + nameof(FeatureToggleSnapshot);
    }
    public string GetAll() {
        return GetFor("all");
    }
}

class FeatureToggle : FeatureToggleSnapshot
{
    public override string GetFor(string key) {
        return key + nameof(FeatureToggle);
    }
}