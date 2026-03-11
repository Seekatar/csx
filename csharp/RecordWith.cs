using static System.Console;


var defaultClientOption = new DefaultClientOption
{
   SourceDb = "SourceDb",
   ConsumerSourceDb = "ConsumerSourceDb"
};

var newConsumerClientConfig = defaultClientOption with
{
   SourceDb = defaultClientOption.ConsumerSourceDb
};

WriteLine($"SourceDb: {defaultClientOption.SourceDb}");
WriteLine($"SourceDb: {newConsumerClientConfig.SourceDb}");

public record NewClientConfig
{
   public string SourceDb { get; set; }
   public string TargetDb { get; set; }
}

public record DefaultClientOption : NewClientConfig
{
   public string ConsumerSourceDb { get; set; }
}

public record Test {
   public string SourceDb { get; set; }
   public string TargetDb { get; set; }
};
