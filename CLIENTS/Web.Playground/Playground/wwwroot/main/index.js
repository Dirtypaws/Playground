var Main=function(){var t=$("#examples").isotope({itemSelector:".grid-item",layout:"masonry",masonry:{columnWidth:240}}),o=[{text:"Kendo",id:"kendo"},{text:"Bootstrap",id:"bootstrap"}],e=$("#ddl_groups").select2({data:o,tags:!0,placeholder:"Filter by application..."});return $(".grid-item").on("click",function(t){window.location.href=_rootUrl+$(this).attr("data-url")}),$("#filters select").on("change",function(o){t.isotope({filter:function(){var t=$(this),o=!1;return null==e.val()||0===e.val().length?o=!0:$.each(e.val(),function(e,a){(t.hasClass(a)||o)&&(o=!0)}),o}})}),{_controls:{iso:t,groups:e}}}();