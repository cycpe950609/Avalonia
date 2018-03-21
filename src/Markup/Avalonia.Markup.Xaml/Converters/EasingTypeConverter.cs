// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using Avalonia.Animation;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Avalonia.Markup.Xaml.Converters
{

    public class EasingTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return Easing.Parse((string)value);
        }
    }
}