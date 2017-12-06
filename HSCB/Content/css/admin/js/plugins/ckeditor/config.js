/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */
 /// ??c.editorConfig cai nay tren tai lieu huong dan
CKEDITOR.editorConfig = function (config){
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    //config.extraPlugins = 'syntaxhighlight';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/css/admin/js/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Content/css/admin/js/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Content/css/admin/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Content/css/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Content/css/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Content/css/admin/js/plugins/ckfinder/');
};
