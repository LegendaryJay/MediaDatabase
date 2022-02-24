﻿using System.Collections.Generic;
using MediaLibrary.Entities;
using MediaLibrary.Menu.MenuStuff.Core;
using Xunit;

namespace MediaLibrary.Tests
{
    public class MenuStructureCoreTests
    {
        
        [Fact]
        public void PassingTest()
        {
            var movie = new Movie()
            {
                Id = 1,
                Genres = new List<string>(){"Action", "Adventure"},
                Title = "This Is a Title (2006)"
            };
            Assert.Equal(" - Movie 1: This Is a Title (2006)\n\tAction, Adventure", movie.ToPrettyString());
        }
    }
}