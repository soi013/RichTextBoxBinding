using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;

namespace RichTextBoxBinding
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _NormalText = "NormalText in VM";
        public string NormalText
        {
            get => _NormalText;
            set
            {
                _NormalText = value;
                RaisePropertyChanged();
            }
        }


        private Brush _TextColor = new SolidColorBrush(Colors.DarkCyan);
        public Brush TextColor
        {
            get => _TextColor;
            set
            {
                _TextColor = value;
                RaisePropertyChanged();
            }
        }


        private FlowDocument _Document = CreateFlowDoc("FlowDocument in VM");
        public FlowDocument Document
        {
            get => _Document;
            set
            {
                _Document = value;
                RaisePropertyChanged();
            }
        }


private RichTextViewModel _RichVM = new RichTextViewModel() { Text = "Original Text in VM", Color = Colors.Indigo };
public RichTextViewModel RichVM
{
    get => _RichVM;
    set
    {
        _RichVM = value;
        RaisePropertyChanged();
    }
}

        private bool _Changed;
        public bool Changed
        {
            get => _Changed;
            set
            {
                _Changed = value;
                RaisePropertyChanged();
                ChangeDocument(value);
            }
        }

        private void ChangeDocument(bool change)
        {
            NormalText = $"NormalText in VM: {DateTime.Now:HH-mm-ss.fff}";
            TextColor = new SolidColorBrush(change ? Colors.Purple : Colors.Orange);
            Document = CreateFlowDoc($"FlowDocument in VM Changed: {DateTime.Now:HH-mm-ss.fff}");
            RichVM = new RichTextViewModel
            {
                Text = $"OriginalText in VM: {DateTime.Now:HH-mm-ss.fff}",
                Color = change ? Colors.Purple : Colors.Orange,
            };
        }

        private static FlowDocument CreateFlowDoc(string innerText)
        {
            var paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run("FixText_"));
            paragraph.Inlines.Add(new Run(innerText) { Foreground = new SolidColorBrush(Colors.BlueViolet) });
            return new FlowDocument(paragraph);
        }
    }

public class RichTextViewModel
{
    public string Text { get; set; }
    public Color Color { get; set; }
}
}
