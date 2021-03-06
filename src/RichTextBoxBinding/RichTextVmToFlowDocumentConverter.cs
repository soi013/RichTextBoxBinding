﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace RichTextBoxBinding
{
public class RichTextVmToFlowDocumentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (!(value is RichTextViewModel richVM))
            return Binding.DoNothing;

        var paragraph = new Paragraph();
        paragraph.Inlines.Add(new Run("FixText_"));
        paragraph.Inlines.Add(new Run()
        {
            Text = richVM.Text,
            Foreground = new SolidColorBrush(richVM.Color),
            FontStyle = FontStyles.Italic,
        });
        return new FlowDocument(paragraph);
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}