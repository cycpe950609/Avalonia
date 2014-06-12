﻿// -----------------------------------------------------------------------
// <copyright file="CheckBoxStyle.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Themes.Default
{
    using System;
    using System.Linq;
    using Perspex.Controls;
    using Perspex.Media;
    using Perspex.Shapes;
    using Perspex.Styling;

    public class CheckBoxStyle : Styles
    {
        public CheckBoxStyle()
        {
            this.AddRange(new[]
            {
                new Style(x => x.OfType<CheckBox>())
                {
                    Setters = new[]
                    {
                        new Setter(Button.TemplateProperty, ControlTemplate.Create<CheckBox>(this.Template)),
                    },
                },
                new Style(x => x.OfType<CheckBox>().Template().Id("checkMark"))
                {
                    Setters = new[]
                    {
                        new Setter(TextBlock.VisibilityProperty, Visibility.Hidden),
                    },
                },
                new Style(x => x.OfType<CheckBox>().Class(":checked").Template().Id("checkMark"))
                {
                    Setters = new[]
                    {
                        new Setter(TextBlock.VisibilityProperty, Visibility.Visible),
                    },
                },
            });
        }

        private Control Template(CheckBox control)
        {
            Border result = new Border
            {
                Content = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Gap = 8,
                    Children = new PerspexList<Control>
                    {
                        new Rectangle
                        {
                            Id = "checkBorder",
                            Stroke = Brushes.Black,
                            StrokeThickness = 2,
                            Width = 16,
                            Height = 16,
                            VerticalAlignment = VerticalAlignment.Center,
                        },
                        new Path
                        {
                            Id = "checkMark",
                            Data = StreamGeometry.Parse("M0,0 L10,10 M10,0 L0,10"),
                            Stroke = Brushes.Black,
                            StrokeThickness = 2,
                            VerticalAlignment = VerticalAlignment.Center,
                        },
                        new ContentPresenter
                        {
                        },
                    },
                },
            };

            result.TemplateBinding(control, Border.BackgroundProperty);
            StackPanel stack = (StackPanel)result.Content;
            ContentPresenter cp = (ContentPresenter)stack.Children[2];
            cp.TemplateBinding(control, ContentPresenter.ContentProperty);
            return result;
        }
    }
}
