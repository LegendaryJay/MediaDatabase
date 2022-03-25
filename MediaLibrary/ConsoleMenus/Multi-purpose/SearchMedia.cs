using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.FileInteractions;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;
using static MediaLibrary.ConsoleMenus.Tools.ManualInputTools;

namespace MediaLibrary.ConsoleMenus.Multi_purpose
{
    public class SearchMedia
    {
        private readonly int _level;
        private readonly IEnumerable<MediaType> _mediaTypes;

        public SearchMedia(IEnumerable<MediaType> mediaTypes, int level)
        {
            _level = level;
            _mediaTypes = mediaTypes;
        }

        public SearchMedia(MediaType mediaType, int level) : this(new[] {mediaType}, level)
        {
        }

        private IEnumerable<Media> GetMedia()
        {
            return _mediaTypes
                .SelectMany(x => MediaFileIoFactory.GetFileIo(x).GetAll()
                );
        }


        private static IEnumerable<Media> Filter(IEnumerable<Media> media, string compareString)
        {
            return media.Where(
                x =>
                    compareString
                        .Split(' ')
                        .Any(
                            y =>
                                x.Title
                                    .IndexOf(y, StringComparison.OrdinalIgnoreCase) >= 0)
            );
        }

        public void Run()
        {
            if (!Ask("Title Search", out var input))
            {
                return;
            }
                
            new DisplayMenu<Media>(Filter(GetMedia(), input).ToList(), x => x.ToPrettyString(), $"Results for \"{input}\"", _level).Run();
        }
    }
}