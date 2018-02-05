/// <reference path="jquery-1.10.2.min.js" />
(function ($) {
    var surveyobj = $(this);
    var itemtype = ["单选", "多选", "问答"];
    //定义克隆对象
    var surverItemElement;
    var surverItemTitleElement;
    var surverItemLi;
    $.fn.extend({
        initsurvey: function (surveyoption) {
            var defaultOption = {
                datainfo: '',
                showtoolbar: true,
                description: '调查问卷',
                optionnum: ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"],
                hasanswer: false//是否有正确答案
            };
            var newOption = {};
            $.extend(newOption, defaultOption, surveyoption);
            surveyobj.surveyoption = newOption;
            surverItemElement = $('.surveyitem').clone();
            surverItemTitleElement = $('.surveyitemtitle').clone();
            surverItemLi = $('.surveyliitem').clone();
            $('.surveyitem').remove();
            $('#bt_radio').bind("click", add_Radio);
            if (!newOption.hasanswer) {
                $('#bt_multiple').bind("click", add_Multiple);
                $('#bt_text').bind("click", add_Text);
            }
            else {
                $('#bt_radio').trigger("click");
            }
            if (!newOption.showtoolbar) {
                $('.surveytoolbar').hide();
            }
            if (newOption.datainfo && newOption.datainfo.length > 10) {
                newOption.datainfo = newOption.datainfo.replace(/&quot;/g, "\"");
                fillSurvey(newOption.datainfo);
            }
            return surveyobj;
        },
        getsurveydata: getSurveyData
    });

    //删除调研大项
    function del_surveritem() {
        $(this).closest(".surveyitem").remove();
    }

    //删除调研大项中的小项
    function del_surveritem_liitem() {
        var ul = $(this).closest("ul");
        var len = $(ul).find("li").length;
        if (len == 1) {
            return false;
        }
        $(this).closest("li").remove();
        reSortItem(ul);
    }

    //重新排序调查问卷顺序
    function reSortItem(ul) {
        var selectAnswer;
        if (surveyobj.surveyoption.hasanswer) {
            selectAnswer = $(ul).next('.surveyanswerdiv').find('.surveyanswertitle_select');
            $(selectAnswer).find('option').remove();
        }
        $(ul).find("li").each(function (i, item) {
            var optionText = surveyobj.surveyoption.optionnum[i];
            $(item).find('.surveyliitem_index').text(optionText);
            if (surveyobj.surveyoption.hasanswer) {
                addansweroption(selectAnswer, optionText);
            }
        });

    }

    //添加调研大项中的小项
    function add_surveritem_liitem() {
        var ul = $(this).closest("ul");
        if ($(ul).find("li").length > 14) {
            return false;
        }
        var _surverItemLi = $(surverItemLi).clone();
        var emeli = document.createElement("li");
        $(emeli).append(_surverItemLi);
        //$(emeli).trigger("create");
        $(emeli).find(".surveyli_button_del").bind("click", del_surveritem_liitem);//调研整项里a,b,c小项删除事件绑定
        $(emeli).find(".surveyli_button_add").bind("click", add_surveritem_liitem);//调研整项里a,b,c小项添加事件绑定
        //$(ul).append(emeli);
        $(emeli).insertAfter($(this).closest("li"));
        reSortItem(ul);
        return emeli;
    }

    function add_Radio() {
        if (surveyobj.surveyoption.hasanswer && $(".surveyitem").length > 0) {
            return false;
        }
        return addSurveyItem(0);
    }

    function add_Multiple() {
        return addSurveyItem(1);
    }

    function add_Text() {
        return addSurveyItem(2);
    }

    function addSurveyItem(itemtypeindex) {
        var ele = $(surverItemElement).clone();
        //alert($(ele).find(".surveyitemtitle_labletype").text());
        $(ele).find(".surveyitemtitle_labletype").text('(' + itemtype[itemtypeindex] + ')');
        $(ele).find(".surveyitem_del").bind("click", del_surveritem);//调研整项删除事件绑定
        if (itemtypeindex == 2) {
            $(ele).find("ul").remove();
        }
        else {
            $(ele).find(".surveyli_button_del").bind("click", del_surveritem_liitem);//调研整项里a,b,c小项删除事件绑定
            $(ele).find(".surveyli_button_add").bind("click", add_surveritem_liitem);//调研整项里a,b,c小项添加事件绑定
        }
        if (surveyobj.surveyoption.hasanswer) {
            //隐藏删除按钮
            $(ele).find(".surveyitem_del").hide();
            //添加答案对象
            addanswer(ele, surveyobj.surveyoption.optionnum[0]);
        }
        $(ele).show();
        $(ele).insertBefore($('.surveytoolbar'));
        return ele;
    }

    function addanswer(ele, answeroption) {
        var answerHtml = '<div class="surveyanswerdiv">\n' +
                                '<span class="surveyanswer_lable">正确答案</span>\n' +
                                '<select class="input surveyanswertitle_select">\n' +
                                '</select>\n' +
                                '</div>'
        $(ele).append(answerHtml);
        if (answeroption && answeroption.length > 0) {
            addansweroption($(ele).find('.surveyanswertitle_select'), surveyobj.surveyoption.optionnum[0]);
        }
    }

    function addansweroption(answerselect, optiontext) {
        $(answerselect).append('<option ="' + optiontext + '">' + optiontext + '</option>\n')
    }

    //编辑情况下填充调研数据
    function fillSurvey(surveydata) {
        var jsonSurveyData = JSON.parse(surveydata);
        $(jsonSurveyData.Question).each(function (i, item) {
            var ele = $(surverItemElement).clone();
            $(ele).find(".surveyitemtitle_labletype").text(item.Type);
            $(ele).find(".surveyitemtitle_labletext").val(item.Subject);
            $(ele).find(".surveyitem_del").bind("click", del_surveritem);//调研整项删除事件绑定
            //调研大项
            console.log(item.Type + '   ' + itemtype[2]);
            if (item.Type.indexOf(itemtype[2]) == -1) {
                $(ele).find("li").remove();
                //alert($(ele).find(".surveyitemtitle_labletype").text());
                //添加答案
                if (surveyobj.surveyoption.hasanswer) {
                    addanswer(ele, '');
                }
                //添加子项
                var $ul = $(ele).find("ul");
                $(item.Option).each(function (cindex, option) {
                    var _surverItemLi = $(surverItemLi).clone();
                    $(_surverItemLi).find(".surveyli_input").val(option.Text);
                    $(_surverItemLi).find(".surveyliitem_index").text(option.Index);
                    var emeli = document.createElement("li");
                    $(emeli).append(_surverItemLi);
                    //$(emeli).trigger("create");
                    $(emeli).find(".surveyli_button_del").bind("click", del_surveritem_liitem);//调研整项里a,b,c小项删除事件绑定
                    $(emeli).find(".surveyli_button_add").bind("click", add_surveritem_liitem);//调研整项里a,b,c小项添加事件绑定
                    $ul.append(emeli);
                    //添加答案项目
                    if (surveyobj.surveyoption.hasanswer) {
                        addansweroption($(ele).find('.surveyanswertitle_select'), option.Index);
                    }
                })
                //选中正确答案
                if (surveyobj.surveyoption.hasanswer) {
                    $(ele).find('.surveyanswertitle_select').val(item.Right);
                }
            }
            else {
                $(ele).find("ul").remove();
            }
            $(ele).show();
            $(ele).insertBefore($('.surveytoolbar'));

        });
    }

    function getSurveyData() {
        var surveyJson = new Object();
        var pass = true;
        surveyJson.Description = surveyobj.surveyoption.description;
        var datalist = new Array();
        $('.surveyitemtitle_labletext,.surveyli_input').each(function (i, item) {
            if ($(item).val().length == 0) {
                $(item).focus();
                pass = false;
                return pass;
            }
        });
        if (!pass) {
            //alert('问卷调查项不能为空');
        }
        else {
            //收集数据
            $('.surveyitem').each(function (i, item) {
                var surveyInfo = new Object();
                surveyInfo.Index = i;
                surveyInfo.Type = $(item).find(".surveyitemtitle_labletype").text();
                surveyInfo.Subject = $(item).find(".surveyitemtitle_labletext").val();
                surveyInfo.Right = '';
                if (surveyobj.surveyoption.hasanswer) {
                    surveyInfo.Right = $(item).find('.surveyanswertitle_select').val();
                }
                var optionArray = new Array();
                //遍历子项
                $(item).find(".surveyli_input").each(function (j, jitem) {
                    var optionObj = new Object();
                    optionObj.Index = surveyobj.surveyoption.optionnum[j];
                    optionObj.Text = $(jitem).val();
                    optionArray.push(optionObj);
                });
                surveyInfo.Option = optionArray;
                datalist.push(surveyInfo);
            });
        }
        surveyJson.pass = pass;
        surveyJson.Question = datalist;
        return surveyJson;
    }
})(jQuery);