﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _7._7CopyAndersonPause
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DragDropxaml : Page
    {
        public DragDropxaml()
        {
            this.InitializeComponent();
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            //指定复制操作
            e.AcceptedOperation = DataPackageOperation.Copy;

            e.DragUIOverride.Caption = "Custom text here";
            //e.DragUIOverride.SetContentFromBitmapImage(null); 
            e.DragUIOverride.IsCaptionVisible = true; 
            e.DragUIOverride.IsContentVisible = true; 
            e.DragUIOverride.IsGlyphVisible = true; 

            e.Handled = true;
        }

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            //验证被拖过来的是否是文件
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                //获取文件列表
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var storageFile = items[0] as StorageFile;
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                    Image.Source = bitmapImage;
                }
            }
        }
    }
}