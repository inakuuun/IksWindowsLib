using Microsoft.AspNetCore.ResponseCompression;

// Web�A�v���P�[�V�����̃r���_�[���쐬
var builder = WebApplication.CreateBuilder(args);

// ===================================
// �T�[�r�X��DI�R���e�i�ɒǉ�
// MVC�R���g���[���[�ƃr���[�̃T�[�r�X��ǉ�
builder.Services.AddControllersWithViews();
// Razor Pages�̃T�[�r�X��ǉ�
builder.Services.AddRazorPages();

// �A�v���P�[�V�������r���h
var app = builder.Build();

// ===================================
// HTTP���N�G�X�g�p�C�v���C����ݒ�
// �J�����̏ꍇ
if (app.Environment.IsDevelopment())
{
    // WebAssembly�f�o�b�O���[�h��L���ɂ���
    app.UseWebAssemblyDebugging();
}
// �J�����ȊO�̏ꍇ
else
{
    // ��O�n���h�����O�p�̃G���h�|�C���g���w��
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTP����HTTPS�ւ̃��_�C���N�g��L����
app.UseHttpsRedirection();

// Blazor�A�v���P�[�V�����t�@�C�����
app.UseBlazorFrameworkFiles();
// �ÓI�t�@�C���iCSS�AJavaScript�A�摜�Ȃǁj���
app.UseStaticFiles();

// ���[�e�B���O��L����
app.UseRouting();

// Razor Pages���}�b�v
app.MapRazorPages();
// �R���g���[���[���}�b�v
app.MapControllers();
// ���ׂẴ��N�G�X�g��"index.html"�t�@�C���Ƀ}�b�v
app.MapFallbackToFile("index.html");

// �A�v���P�[�V�����̎��s���J�n
app.Run();
