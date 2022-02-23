// using Microsoft.Extensions.Logging;
//
// namespace MediaLibrary
// {
//     public class Logging
//     {
//         IServiceCollection serviceCollection = new ServiceCollection();
//         var serviceProvider = serviceCollection
//             .AddLogging(x=>x.AddConsole())
//             .BuildServiceProvider();
//         var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
//     }
// }