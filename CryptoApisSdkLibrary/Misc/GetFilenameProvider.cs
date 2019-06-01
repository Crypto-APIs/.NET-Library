using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CryptoApisSdkLibrary.Misc
{
    public class GetFilenameProvider : IFilenameProvider
    {
        public GetFilenameProvider(string[] possibleFilenames)
        {
            _possibleFilenames.AddRange(possibleFilenames);
        }

        private readonly List<string> _possibleFilenames = new List<string>();

        public string Filename => _possibleFilenames.FirstOrDefault(File.Exists);
    }

    public interface IFilenameProvider
    {
        string Filename { get; }
    }
}