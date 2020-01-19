﻿using System.Threading.Tasks;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class ItalicCommand<TStorageFile, TStream> : SimpleCommand<DocumentViewModel<TStorageFile, TStream>>
        where TStream : class
    {
        public ItalicCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.BeginUndoGroup();
                //set the selected text to be bold if not already
                //if the text is already bold it will make it regular
                var selectedText = viewModel.SelectedText;
                if (string.IsNullOrWhiteSpace(selectedText))
                {
                    viewModel.Document.SelItalic = !viewModel.Document.SelItalic;
                }

                viewModel.Document.EndUndoGroup();

                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}