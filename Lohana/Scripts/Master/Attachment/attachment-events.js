$(document).ready(function () {

    GetImages();

    GetImagesByRefType();

    $("#imageUpload").uploadify(
                {
                    height: 30,
                    buttonText: 'BROWSE...',
                    swf: '/Content/plugin/uploadify/uploadify.swf',
                    uploader: '/Accessories/Upload',
                    width: 120,
                    onUploadSuccess: function () { },
                    cancelImg: '/Content/plugin/uploadify/uploadify-cancel.png',
                    removeCompleted: false,
                    onUploadSuccess: function (file, data, response, count) {

                        $("[name='Accessories.AttachmentName']").val(file.name);
                        SaveImage();
                    }

                }); 
});