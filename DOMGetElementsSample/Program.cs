﻿#region Copyright

// Copyright 2019, TeamDev. All rights reserved.
// 
// Redistribution and use in source and/or binary forms, with or without
// modification, must retain the above copyright notice and the following
// disclaimer.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using DotNetBrowser.Browser;
using DotNetBrowser.Dom;
using DotNetBrowser.Engine;
using DotNetBrowser.Geometry;

namespace DOMGetElementsSample
{
    internal class Program
    {
        #region Methods

        public static void Main()
        {
            try
            {
                using (IEngine engine = EngineFactory.Create(new EngineOptions.Builder().Build()))
                {
                    Console.WriteLine("Engine created");

                    using (IBrowser browser = engine.CreateBrowser())
                    {
                        Console.WriteLine("Browser created");

                        browser.Navigation.LoadUrl("http://www.google.com")
                               .Wait();
                        IDocument document = browser.MainFrame.Document;
                        IEnumerable<INode> divs = document.GetElementsByTagName("div");
                        foreach (INode div in divs)
                        {
                            if (div is IElement divElement)
                            {
                                Rectangle boundingClientRect = divElement.BoundingClientRect;
                                Console
                                    .Out.WriteLine(@"class = {0}; boundingClientRect.Top = {1}; boundingClientRect.Left = {2}; boundingClientRect.Width = {3}; boundingClientRect.Height = {4}"
                                                   , divElement.Attributes["class"]
                                                   , boundingClientRect.OriginPoint.Y
                                                   , boundingClientRect.OriginPoint.X
                                                   , boundingClientRect.Size.Width
                                                   , boundingClientRect.Size.Height
                                                  );
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Press any key to terminate...");
            Console.ReadKey();
        }

        #endregion
    }
}