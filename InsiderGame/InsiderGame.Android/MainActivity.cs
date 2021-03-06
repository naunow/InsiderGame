﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace InsiderGame.Droid
{
    [Activity(Label = "InsiderGame", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // フルスクリーンにする
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            //{
            //    this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            //    this.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            //}

            //var systemUiFlags = SystemUiFlags.LayoutStable
            //| SystemUiFlags.LayoutHideNavigation
            //| SystemUiFlags.LayoutFullscreen
            //| SystemUiFlags.HideNavigation
            //| SystemUiFlags.Fullscreen
            //| SystemUiFlags.ImmersiveSticky;
            //Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(int)systemUiFlags;

            // DBパスの設定
            string fileName = "insidergame_db.sqlite";
            // string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileLocation = GetExternalFilesDir(null).ToString();
            string full_path = Path.Combine(fileLocation, fileName);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            LoadApplication(new App(full_path));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}