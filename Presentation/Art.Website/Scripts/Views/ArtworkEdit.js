/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />
/// <reference path="base/ViewBase.js" />


(function () {
    art.ui.view.ArtworkEdit = ArtworkEditClass;

    function ArtworkEditClass() {
        var _self = this;

        art.ui.view.ViewBase.call(_self);

        function _init() {
            _self.init = init;

            _self.bindModel = bindModel;

            _self.save = save;
        }

        function init() {
            initDomEvent();
            initDomElement();
            initValidation();
        }

        function initDomEvent() {
            var adminjs = new adminglass();
            adminjs.datepickerbox('.datepicker');

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
        }

        function initDomElement() {
            _self.attachBindingAttribute();
        }

        function initValidation() {
            var options = {
                onkeyup: false,
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
                if (viewModel.Artwork.AuctionType == 1) {
                    return true;
                }
                if (viewModel.Artwork.EndDateTime <= viewModel.Artwork.StartDateTime) {
                    return false;
                }
                return true;
            }, "请正确输入时间，并且开始时间不能晚于结束时间");

            options.rules["Artwork.StartDateTime"] = { DateValidate: true };
            options.rules["Artwork.EndDateTime"] = { DateValidate: true };

            options.rules["Artwork.FeePackageGeneral"] = { number: true, required: "[name='Artwork.FeePackageGeneralEnabled']:checked" };
            options.rules["Artwork.FeePackageFine"] = { number: true, required: "[name='Artwork.FeePackageFineEnabled']:checked" };
            options.rules["Artwork.FeeDeliveryLocal"] = { number: true, required: "[name='Artwork.FeeDeliveryLocalEnabled']:checked" };
            options.rules["Artwork.FeeDeliveryNonLocal"] = { number: true, required: "[name='Artwork.FeeDeliveryNonLocalEnabled']:checked" };
            

            jQuery.validator.addMethod("require_from_group", function (value, element, options) {
                var flg = $(options[1]).filter(":checked").length > 0;
                if (flg) {
                    $(options[1]).filter("label.error").hide();
                }
                return flg;
            }, "至少选择一种方式");

            jQuery.validator.addClassRules("FeePackage", {
                require_from_group: [1, ".FeePackage"]
            });

            jQuery.validator.addClassRules("FeeDelivery", {
                require_from_group: [1, ".FeeDelivery"]
            });
            

            $("form").validate(options);
        }

        function bindModel(model) {
            parseModel(model);

            viewModel = kendo.observable(model);

            viewModel.Artwork.bind("change", function (item) {
                if (item.field == "Artwork.ArtworkTypeId") {
                    var artworkTypeId = item.sender.get();
                    var artworkType = $.grep(model.SourceArtworkTypes, function (element, index) {
                        return element.Id == artworkTypeId;
                    })[0];

                    var materials = getArtworkTypeSubItem(artworkType, "ArtMaterials");
                    viewModel.set("SourceArtMaterials", materials);
                    viewModel.Artwork.set("ArtMaterialId", "");

                    var shapes = getArtworkTypeSubItem(artworkType, "ArtShapes");
                    viewModel.set("SourceArtShapes", shapes);
                    viewModel.Artwork.set("ArtShapeId", "");

                    var materials = getArtworkTypeSubItem(artworkType, "ArtTechniques");
                    viewModel.set("SourceArtTechniques", materials);
                    viewModel.Artwork.set("ArtTechniqueId", "");
                }
            });

            kendo.bind($("form"), viewModel);
        }

        function getArtworkTypeSubItem(artworkType, itemTypeName) {
            var sourceItems = [{ Id: "", Text: "未选" }];
            if (!artworkType) {
                return sourceItems;
            }
            for (var i = 0; i < artworkType[itemTypeName].length; i++) {
                sourceItems.push(artworkType[itemTypeName][i]);
            }
            return sourceItems;
        }

        function parseModel(model) {
            for (var i = 0; i < model.Artwork.SuitablePlaceIds.length; i++) {
                model.Artwork.SuitablePlaceIds[i] += "";
            }

            if (model.Artwork.ImageFileName) {
                model.Artwork.ImageFileName = webExpress.utility.url.getFullUrl(model.Artwork.ImageFileName);
            }

            var artworkType = $.grep(model.SourceArtworkTypes, function (element, index) {
                return element.Id == model.Artwork.ArtworkTypeId;
            })[0];

            if (model.Artwork.Id == 0) {
                model.Artwork.AuctionPrice = "";
                model.Artwork.AuctionType = art.config.enums.AuctionTypes.一口价;
            }

            model.SourceArtMaterials = getArtworkTypeSubItem(artworkType, "ArtMaterials");
            model.SourceArtShapes = getArtworkTypeSubItem(artworkType, "ArtShapes");
            model.SourceArtTechniques = getArtworkTypeSubItem(artworkType, "ArtTechniques"); model.IsHideAuctionDateTime = model.Artwork.AuctionType == 1;

            model.IsHideAuctionDateTime = model.Artwork.AuctionType == art.config.enums.AuctionTypes.一口价;
            model.switchActionType = function (e) {
                this.set("IsHideAuctionDateTime", e.currentTarget.value == art.config.enums.AuctionTypes.一口价);
            }
        }

        function save(model) {
            var url = model.Artwork.Id > 0 ? "/Artwork/Update" : "/Artwork/Add";
            webExpress.utility.ajax.request(url, model.Artwork,
            function () {
                alert("保存成功");
                location.href = location.href;
            },
            function () {
                alert("保存错误");
            });
        }

        _init();
    }
})();