(function(a) {
    a.fn.daterangepicker = function(s) {
        var d = a(this);
        var e = a.extend({
            presetRanges: [
                { text: "Today", dateStart: "today", dateEnd: "today" }, { text: "Last 7 days", dateStart: "today-7days", dateEnd: "today" }, { text: "Month to date", dateStart: function() { return Date.parse("today").moveToFirstDayOfMonth(); }, dateEnd: "today" }, {
                    text: "Year to date",
                    dateStart: function() {
                        var w = Date.parse("today");
                        w.setMonth(0);
                        w.setDate(1);
                        return w;
                    },
                    dateEnd: "today"
                }, { text: "The previous Month", dateStart: function() { return Date.parse("1 month ago").moveToFirstDayOfMonth(); }, dateEnd: function() { return Date.parse("1 month ago").moveToLastDayOfMonth(); } }
            ],
            presets: { specificDate: "Specific Date", allDatesBefore: "All Dates Before", allDatesAfter: "All Dates After", dateRange: "Date Range" },
            rangeStartTitle: "Start date",
            rangeEndTitle: "End date",
            nextLinkText: "Next",
            prevLinkText: "Prev",
            target: d,
            doneButtonText: "Done",
            earliestDate: Date.parse("-15years"),
            latestDate: Date.parse("+15years"),
            constrainDates: false,
            rangeSplitter: "-",
            dateFormat: "m/d/yy",
            closeOnSelect: true,
            arrows: false,
            appendTo: "body",
            onClose: function() {},
            onOpen: function() {},
            onChange: function() {},
            datepickerOptions: null
        }, s);
        var g = {
            onSelect: function(A, z) {
                var y = j.find(".range-start");
                var B = j.find(".range-end");
                if (j.find(".ui-daterangepicker-specificDate").is(".ui-state-active")) {
                    B.datepicker("setDate", y.datepicker("getDate"));
                }
                a(this).trigger("constrainOtherPicker");
                var x = b(y.datepicker("getDate"));
                var w = b(B.datepicker("getDate"));
                if (d.length == 2) {
                    d.eq(0).val(x);
                    d.eq(1).val(w);
                } else {
                    d.val((x != w) ? x + " " + e.rangeSplitter + " " + w : x);
                }
                if (e.closeOnSelect) {
                    if (!j.find("li.ui-state-active").is(".ui-daterangepicker-dateRange") && !j.is(":animated")) {
                        k();
                    }
                    a(this).trigger("constrainOtherPicker");
                    e.onChange();
                }
            },
            defaultDate: +0
        };
        d.bind("change", e.onChange);
        e.datepickerOptions = (s) ? a.extend(g, s.datepickerOptions) : g;
        var m, l = Date.parse("today");
        var o, i;
        if (d.size() == 2) {
            o = Date.parse(d.eq(0).val());
            i = Date.parse(d.eq(1).val());
            if (o == null) {
                o = i;
            }
            if (i == null) {
                i = o;
            }
        } else {
            o = Date.parse(d.val().split(e.rangeSplitter)[0]);
            i = Date.parse(d.val().split(e.rangeSplitter)[1]);
            if (i == null) {
                i = o;
            }
        }
        if (o != null) {
            m = o;
        }
        if (i != null) {
            l = i;
        }
        var j = a('<div class="ui-daterangepicker ui-widget ui-helper-clearfix ui-widget-content ui-corner-all"></div>');
        var u = (function() {
            var y = a('<ul class="ui-widget-content"></ul>').appendTo(j);
            a.each(e.presetRanges, function() { a('<li class="ui-daterangepicker-' + text.replace(/ /g, "") + ' ui-corner-all"><a href="#">' + text + "</a></li>").data("dateStart", dateStart).data("dateEnd", dateEnd).appendTo(y); });
            var w = 0;
            a.each(e.presets, function(x, z) {
                a('<li class="ui-daterangepicker-' + x + " preset_" + w + ' ui-helper-clearfix ui-corner-all"><span class="ui-icon ui-icon-triangle-1-e"></span><a href="#">' + z + "</a></li>").appendTo(y);
                w++;
            });
            y.find("li").hover(function() { a(this).addClass("ui-state-hover"); }, function() { a(this).removeClass("ui-state-hover"); }).click(function() {
                j.find(".ui-state-active").removeClass("ui-state-active");
                a(this).addClass("ui-state-active");
                q(a(this), j, n, f);
                return false;
            });
            return y;
        })();

        function b(y) {
            if (!y.getDate()) {
                return"";
            }
            var x = y.getDate();
            var A = y.getMonth();
            var z = y.getFullYear();
            A++;
            var w = e.dateFormat;
            return a.datepicker.formatDate(w, y);
        }

        a.fn.restoreDateFromData = function() {
            if (a(this).data("saveDate")) {
                a(this).datepicker("setDate", a(this).data("saveDate")).removeData("saveDate");
            }
            return this;
        };
        a.fn.saveDateToData = function() {
            if (!a(this).data("saveDate")) {
                a(this).data("saveDate", a(this).datepicker("getDate"));
            }
            return this;
        };

        function t() {
            if (j.data("state") == "closed") {
                v();
                j.fadeIn(300).data("state", "open");
                e.onOpen();
            }
        }

        function k() {
            if (j.data("state") == "open") {
                j.fadeOut(300).data("state", "closed");
                e.onClose();
            }
        }

        function c() {
            if (j.data("state") == "open") {
                k();
            } else {
                t();
            }
        }

        function v() {
            var w = p || d;
            var A = w.offset(), y = "left", z = A.left, x = a(window).width() - z - w.outerWidth();
            if (z > x) {
                y = "right", z = x;
            }
            j.parent().css(y, z).css("top", A.top + w.outerHeight());
        }

        function q(z, y, A, w) {
            if (z.is(".ui-daterangepicker-specificDate")) {
                w.hide();
                A.show();
                y.find(".title-start").text(e.presets.specificDate);
                y.find(".range-start").restoreDateFromData().css("opacity", 1).show(400);
                y.find(".range-end").restoreDateFromData().css("opacity", 0).hide(400);
                setTimeout(function() { w.fadeIn(); }, 400);
            } else {
                if (z.is(".ui-daterangepicker-allDatesBefore")) {
                    w.hide();
                    A.show();
                    y.find(".title-end").text(e.presets.allDatesBefore);
                    y.find(".range-start").saveDateToData().datepicker("setDate", e.earliestDate).css("opacity", 0).hide(400);
                    y.find(".range-end").restoreDateFromData().css("opacity", 1).show(400);
                    setTimeout(function() { w.fadeIn(); }, 400);
                } else {
                    if (z.is(".ui-daterangepicker-allDatesAfter")) {
                        w.hide();
                        A.show();
                        y.find(".title-start").text(e.presets.allDatesAfter);
                        y.find(".range-start").restoreDateFromData().css("opacity", 1).show(400);
                        y.find(".range-end").saveDateToData().datepicker("setDate", e.latestDate).css("opacity", 0).hide(400);
                        setTimeout(function() { w.fadeIn(); }, 400);
                    } else {
                        if (z.is(".ui-daterangepicker-dateRange")) {
                            w.hide();
                            A.show();
                            y.find(".title-start").text(e.rangeStartTitle);
                            y.find(".title-end").text(e.rangeEndTitle);
                            y.find(".range-start").restoreDateFromData().css("opacity", 1).show(400);
                            y.find(".range-end").restoreDateFromData().css("opacity", 1).show(400);
                            setTimeout(function() { w.fadeIn(); }, 400);
                        } else {
                            w.hide();
                            y.find(".range-start, .range-end").css("opacity", 0).hide(400, function() { A.hide(); });
                            var B = (typeof z.data("dateStart") == "string") ? Date.parse(z.data("dateStart")) : z.data("dateStart")();
                            var x = (typeof z.data("dateEnd") == "string") ? Date.parse(z.data("dateEnd")) : z.data("dateEnd")();
                            y.find(".range-start").datepicker("setDate", B).find(".ui-datepicker-current-day").trigger("click");
                            y.find(".range-end").datepicker("setDate", x).find(".ui-datepicker-current-day").trigger("click");
                        }
                    }
                }
            }
            return false;
        }

        var n = a('<div class="ranges ui-widget-header ui-corner-all ui-helper-clearfix"><div class="range-start"><span class="title-start">Start Date</span></div><div class="range-end"><span class="title-end">End Date</span></div></div>').appendTo(j);
        n.find(".range-start, .range-end").datepicker(e.datepickerOptions);
        n.find(".range-start").datepicker("setDate", m);
        n.find(".range-end").datepicker("setDate", l);
        n.find(".range-start, .range-end").bind("constrainOtherPicker", function() {
            if (e.constrainDates) {
                if (a(this).is(".range-start")) {
                    j.find(".range-end").datepicker("option", "minDate", a(this).datepicker("getDate"));
                } else {
                    j.find(".range-start").datepicker("option", "maxDate", a(this).datepicker("getDate"));
                }
            }
        }).trigger("constrainOtherPicker");
        var f = a('<button class="btnDone ui-state-default ui-corner-all">' + e.doneButtonText + "</button>").click(function() {
            j.find(".ui-datepicker-current-day").trigger("click");
            k();
        }).hover(function() { a(this).addClass("ui-state-hover"); }, function() { a(this).removeClass("ui-state-hover"); }).appendTo(n);
        a(this).click(function() {
            c();
            return false;
        });
        n.hide().find(".range-start, .range-end, .btnDone").hide();
        j.data("state", "closed");
        n.find(".ui-datepicker").css("display", "block");
        a(e.appendTo).append(j);
        j.wrap('<div class="ui-daterangepickercontain"></div>');
        if (e.arrows && d.size() == 1) {
            var h = a('<a href="#" class="ui-daterangepicker-prev ui-corner-all" title="' + e.prevLinkText + '"><span class="ui-icon ui-icon-circle-triangle-w">' + e.prevLinkText + "</span></a>");
            var r = a('<a href="#" class="ui-daterangepicker-next ui-corner-all" title="' + e.nextLinkText + '"><span class="ui-icon ui-icon-circle-triangle-e">' + e.nextLinkText + "</span></a>");
            a(this).addClass("ui-rangepicker-input ui-widget-content").wrap('<div class="ui-daterangepicker-arrows ui-widget ui-widget-header ui-helper-clearfix ui-corner-all"></div>').before(h).before(r).parent().find("a").click(function() {
                var x = n.find(".range-start").datepicker("getDate");
                var w = n.find(".range-end").datepicker("getDate");
                var y = Math.abs(new TimeSpan(x - w).getTotalMilliseconds()) + 86400000;
                if (a(this).is(".ui-daterangepicker-prev")) {
                    y = -y;
                }
                n.find(".range-start, .range-end").each(function() {
                    var z = a(this).datepicker("getDate");
                    if (z == null) {
                        return false;
                    }
                    a(this).datepicker("setDate", z.add({ milliseconds: y })).find(".ui-datepicker-current-day").trigger("click");
                });
                return false;
            }).hover(function() { a(this).addClass("ui-state-hover"); }, function() { a(this).removeClass("ui-state-hover"); });
            var p = d.parent();
        }
        a(document).click(function() {
            if (j.is(":visible")) {
                k();
            }
        });
        j.click(function() { return false; }).hide();
        return this;
    };
})(jQuery);