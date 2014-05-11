/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    art.ui.view.ArtistEdit = ArtistEditClass;

    function ArtistEditClass() {
        var _self = this;
        var _adminJs = new adminglass();
        art.ui.view.ViewBase.call(_self);

        function _init() {
            _self.init = init;

            _self.bindModel = bindModel;
        }

        function init() {
            initDomEvent();
            initDomElement();
            initValidation();
        }
        function initDomEvent() {
            $("#J_addbtn").click(function () {
                var isValid = $("form").valid();
                if (isValid) {
                    save(viewModel);
                }
            });

            $(":file").change(function () {
                $("form").validate().cancelSubmit = true;
                $("form").submit();
            });

            $(".J_closebox").click(function () {
                var box = $(this).closest(".add-openbox");
                _adminJs.closewinbox(box);
            });

            $("#btnConfirmToAddArtwork").click(function () {
                location.href = "/Artwork/Add?artistId=" + viewModel.Artist.Id;
            });

            $("#btnConfirmToAddArtist").click(function () {
                location.href = "/Artist/Add";
            });

            $("#btnConfirm").click(function () {
                location.href = location.href;
            });

            $("#btnCancel").click(function () {
                var box = $(this).closest(".add-openbox");
                _adminJs.closewinbox(box);
            });

            $("#J_quxiaobtn").click(function () {
                _adminJs.openwinbox('#J_add-quxiaobox');
            });

            $("iframe").load(iframeFileUpload_onload);
        }

        function initDomElement() {
            _self.attachBindingAttribute();
        }

        function initValidation() {
            var options = {
                ignore: [],
                rules: {}
            };
            var properties = $("[property-name]");
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                if ($property.hasClass("mandatory")) {
                    var propName = $property.attr("property-name");
                    options.rules[propName] = { required: true };
                }
            }

            jQuery.validator.addMethod("DateValidate", function (value, element) {
                var re = /^\d{4}-\d{1,2}-\d{1,2}$/;
                return re.test(viewModel.Artist.Birthday);
            }, "请填写日期");

            jQuery.validator.addMethod("DeathdayValidate", function (value, element) {
                if (viewModel.Artist.Deathday == "") {
                    return true;
                }
                var re = /^\d{4}-\d{1,2}-\d{1,2}$/;
                return re.test(viewModel.Artist.Birthday);
            }, "请填写日期");
            

            options.rules["Artist.Birthday"] = { DateValidate: true };
            options.rules["Artist.Deathday"] = { DeathdayValidate: true };

            $("form").validate(options);
        }

        function bindModel(model) {
            parseModel(model);

            viewModel = kendo.observable(model);

            kendo.bind($("form"), viewModel);
        }

        function parseModel(model) {
            for (var i = 0; i < model.Artist.ArtistTypeIds.length; i++) {
                model.Artist.ArtistTypeIds[i] += "";
            }

            for (var i = 0; i < model.Artist.SkilledGenreIds.length; i++) {
                model.Artist.SkilledGenreIds[i] += "";
            }

            if (model.Artist.Birthday) {
                model.Artist.Birthday = model.Artist.Birthday.substr(0, 10);
            }

            if (model.Artist.Deathday) {
                model.Artist.Deathday = model.Artist.Deathday.substr(0, 10);
            }

            if (model.Artist.AvatarFileName) {
                model.Artist.AvatarFileName = webExpress.utility.url.getFullUrl(model.Artist.AvatarFileName);
            }

            model.ArtworkTypes.unshift({ Value: "", Text: "未选" });
            model.Degrees.unshift({ Value: "", Text: "未选" });
        }

        function save(model) {
            var isEditModel = model.Artist.Id > 0 ;
            var url = isEditModel ? "/Artist/Update" : "/Artist/Add";
            webExpress.utility.ajax.request(url, model.Artist,
            function (response) {
                if (isEditModel) {
                    alert("保存成功");
                }
                else {
                    viewModel.Artist.set("Id", response.Data);
                    console.dir(response);
                    _adminJs.openwinbox('#J_add-openbox');
                }
                
            },
            function () {
                alert("error");
            });
        }

        function iframeFileUpload_onload() {
            var jsonString = $(this).contents().find("body").html();
            var model = $.parseJSON(jsonString);
            if (model.IsSuccess) {
                var fullFilePath = webExpress.utility.url.getFullUrl(model.UploadedFileName);
                viewModel.Artist.set("AvatarFileName", fullFilePath);
            }
            else {
                alert(model.Message);
            }
        }

        _init();
    }
})();