using Microsoft.AspNetCore.ResponseCompression;

// Webアプリケーションのビルダーを作成
var builder = WebApplication.CreateBuilder(args);

// ===================================
// サービスをDIコンテナに追加
// MVCコントローラーとビューのサービスを追加
builder.Services.AddControllersWithViews();
// Razor Pagesのサービスを追加
builder.Services.AddRazorPages();

// アプリケーションをビルド
var app = builder.Build();

// ===================================
// HTTPリクエストパイプラインを設定
// 開発環境の場合
if (app.Environment.IsDevelopment())
{
    // WebAssemblyデバッグモードを有効にする
    app.UseWebAssemblyDebugging();
}
// 開発環境以外の場合
else
{
    // 例外ハンドリング用のエンドポイントを指定
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPからHTTPSへのリダイレクトを有効化
app.UseHttpsRedirection();

// Blazorアプリケーションファイルを提供
app.UseBlazorFrameworkFiles();
// 静的ファイル（CSS、JavaScript、画像など）を提供
app.UseStaticFiles();

// ルーティングを有効化
app.UseRouting();

// Razor Pagesをマップ
app.MapRazorPages();
// コントローラーをマップ
app.MapControllers();
// すべてのリクエストを"index.html"ファイルにマップ
app.MapFallbackToFile("index.html");

// アプリケーションの実行を開始
app.Run();
