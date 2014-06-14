/* ===================================================
 * bootstrap-transition.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#transitions
 * ===================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* CSS TRANSITION SUPPORT (http://www.modernizr.com/)
   * ======================================================= */

    $(function() {
        $.support.transition = (function() {
            var transitionEnd = (function() {
                var el = document.createElement('bootstrap'),
                    transEndEventNames = {
                        'WebkitTransition': 'webkitTransitionEnd',
                        'MozTransition': 'transitionend',
                        'OTransition': 'oTransitionEnd otransitionend',
                        'transition': 'transitionend'
                    },
                    name;
                for (name in transEndEventNames) {
                    if (el.style[name] !== undefined) {
                        return transEndEventNames[name];
                    }
                }
            }());
            return transitionEnd && {
                end: transitionEnd
            };
        })();
    });
}(window.jQuery);
/* =========================================================
 * bootstrap-modal.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#modals
 * =========================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================= */

!function($) {
    "use strict"; // jshint ;_;

    /* MODAL CLASS DEFINITION
  * ====================== */

    var Modal = function(element, options) {
        options = options;
        $element = $(element)
            .delegate('[data-dismiss="modal"]', 'click.dismiss.modal', $.proxy(hide, this));
        options.remote && $element.find('.modal-body').load(options.remote);
    };
    Modal.prototype = {
        constructor: Modal,
        toggle: function() {
            return this[!isShown ? 'show' : 'hide']();
        },
        show: function() {
            var that = this, e = $.Event('show');
            $element.trigger(e);
            if (isShown || e.isDefaultPrevented()) return;
            isShown = true;
            escape();
            backdrop(function() {
                var transition = $.support.transition && that.$element.hasClass('fade');
                if (!that.$element.parent().length) {
                    that.$element.appendTo(document.body); //don't move modals dom position
                }

                that.$element.show();
                if (transition) {
                    that.$element[0].offsetWidth; // force reflow
                }

                that.$element
                    .addClass('in')
                    .attr('aria-hidden', false);
                that.enforceFocus();
                transition ?
                    that.$element.one($.support.transition.end, function() { that.$element.focus().trigger('shown'); }) :
                    that.$element.focus().trigger('shown');
            });
        },
        hide: function(e) {
            e && e.preventDefault();
            var that = this;
            e = $.Event('hide');
            $element.trigger(e);
            if (!isShown || e.isDefaultPrevented()) return;
            isShown = false;
            escape();
            $(document).off('focusin.modal');
            $element
                .removeClass('in')
                .attr('aria-hidden', true);
            $.support.transition && $element.hasClass('fade') ?
                hideWithTransition() :
                hideModal();
        },
        enforceFocus: function() {
            var that = this;
            $(document).on('focusin.modal', function(e) {
                if (that.$element[0] !== e.target && !that.$element.has(e.target).length) {
                    that.$element.focus();
                }
            });
        },
        escape: function() {
            var that = this;
            if (isShown && options.keyboard) {
                $element.on('keyup.dismiss.modal', function(e) {
                    e.which == 27 && that.hide();
                });
            } else if (!isShown) {
                $element.off('keyup.dismiss.modal');
            }
        },
        hideWithTransition: function() {
            var that = this,
                timeout = setTimeout(function() {
                    that.$element.off($.support.transition.end);
                    that.hideModal();
                }, 500);
            $element.one($.support.transition.end, function() {
                clearTimeout(timeout);
                that.hideModal();
            });
        },
        hideModal: function() {
            var that = this;
            $element.hide();
            backdrop(function() {
                that.removeBackdrop();
                that.$element.trigger('hidden');
            });
        },
        removeBackdrop: function() {
            $backdrop.remove();
            $backdrop = null;
        },
        backdrop: function(callback) {
            var that = this, animate = $element.hasClass('fade') ? 'fade' : '';
            if (isShown && options.backdrop) {
                var doAnimate = $.support.transition && animate;
                $backdrop = $('<div class="modal-backdrop ' + animate + '" />')
                    .appendTo(document.body);
                $backdrop.click(
                    options.backdrop == 'static' ?
                    $.proxy($element[0].focus, $element[0])
                    : $.proxy(hide, this)
                );
                if (doAnimate) $backdrop[0].offsetWidth; // force reflow

                $backdrop.addClass('in');
                if (!callback) return;
                doAnimate ?
                    $backdrop.one($.support.transition.end, callback) :
                    callback();
            } else if (!isShown && $backdrop) {
                $backdrop.removeClass('in');
                $.support.transition && $element.hasClass('fade') ?
                    $backdrop.one($.support.transition.end, callback) :
                    callback();
            } else if (callback) {
                callback();
            }
        }
    }; /* MODAL PLUGIN DEFINITION
  * ======================= */

    var old = $.fn.modal;
    $.fn.modal = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('modal'),
                options = $.extend({}, $.fn.modal.defaults, $data(), typeof option == 'object' && option);
            if (!data) $data('modal', (data = new Modal(this, options)));
            if (typeof option == 'string') data[option]();
            else if (options.show) data.show();
        });
    };
    $.fn.modal.defaults = {
        backdrop: true,
        keyboard: true,
        show: true
    };
    $.fn.modal.Constructor = Modal; /* MODAL NO CONFLICT
  * ================= */

    $.fn.modal.noConflict = function() {
        $.fn.modal = old;
        return this;
    }; /* MODAL DATA-API
  * ============== */

    $(document).on('click.modal.data-api', '[data-toggle="modal"]', function(e) {
        var $this = $(this),
            href = $attr('href'),
            $target = $($attr('data-target') || (href && href.replace(/.*(?=#[^\s]+$)/, ''))) //strip for ie7
            ,
            option = $target.data('modal') ? 'toggle' : $.extend({ remote: !/#/.test(href) && href }, $target.data(), $data());
        e.preventDefault();
        $target
            .modal(option)
            .one('hide', function() {
                $focus();
            });
    });
}(window.jQuery);

/* ============================================================
 * bootstrap-dropdown.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#dropdowns
 * ============================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */

!function($) {
    "use strict"; // jshint ;_;

    /* DROPDOWN CLASS DEFINITION
  * ========================= */

    var toggle = '[data-toggle=dropdown]',
        Dropdown = function(element) {
            var $el = $(element).on('click.dropdown.data-api', toggle);
            $('html').on('click.dropdown.data-api', function() {
                $el.parent().removeClass('open');
            });
        };
    Dropdown.prototype = {
        constructor: Dropdown,
        toggle: function(e) {
            var $this = $(this),
                $parent,
                isActive;
            if ($is('.disabled, :disabled')) return;
            $parent = getParent($this);
            isActive = $parent.hasClass('open');
            clearMenus();
            if (!isActive) {
                $parent.toggleClass('open');
            }

            $focus();
            return false;
        },
        keydown: function(e) {
            var $this,
                $items,
                $active,
                $parent,
                isActive,
                index;
            if (!/(38|40|27)/.test(e.keyCode)) return;
            $this = $(this);
            e.preventDefault();
            e.stopPropagation();
            if ($is('.disabled, :disabled')) return;
            $parent = getParent($this);
            isActive = $parent.hasClass('open');
            if (!isActive || (isActive && e.keyCode == 27)) {
                if (e.which == 27) $parent.find(toggle).focus();
                return $click();
            }

            $items = $('[role=menu] li:not(.divider):visible a', $parent);
            if (!$items.length) return;
            index = $items.index($items.filter(':focus'));
            if (e.keyCode == 38 && index > 0) index--; // up
            if (e.keyCode == 40 && index < $items.length - 1) index++; // down
            if (!~index) index = 0;
            $items
                .eq(index)
                .focus();
        }
    };

    function clearMenus() {
        $(toggle).each(function() {
            getParent($(this)).removeClass('open');
        });
    }

    function getParent($this) {
        var selector = $attr('data-target'), $parent;
        if (!selector) {
            selector = $attr('href');
            selector = selector && /#/.test(selector) && selector.replace(/.*(?=#[^\s]*$)/, ''); //strip for ie7
        }

        $parent = selector && $(selector);
        if (!$parent || !$parent.length) $parent = $parent();
        return $parent;
    }

    /* DROPDOWN PLUGIN DEFINITION
   * ========================== */

    var old = $.fn.dropdown;
    $.fn.dropdown = function(option) {
        return each(function() {
            var $this = $(this), data = $data('dropdown');
            if (!data) $data('dropdown', (data = new Dropdown(this)));
            if (typeof option == 'string') data[option].call($this);
        });
    };
    $.fn.dropdown.Constructor = Dropdown; /* DROPDOWN NO CONFLICT
  * ==================== */

    $.fn.dropdown.noConflict = function() {
        $.fn.dropdown = old;
        return this;
    }; /* APPLY TO STANDARD DROPDOWN ELEMENTS
   * =================================== */

    $(document)
        .on('click.dropdown.data-api', clearMenus)
        .on('click.dropdown.data-api', '.dropdown form', function(e) { e.stopPropagation(); })
        .on('.dropdown-menu', function(e) { e.stopPropagation(); })
        .on('click.dropdown.data-api', toggle, Dropdown.prototype.toggle)
        .on('keydown.dropdown.data-api', toggle + ', [role=menu]', Dropdown.prototype.keydown);
}(window.jQuery);

/* =============================================================
 * bootstrap-scrollspy.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#scrollspy
 * =============================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* SCROLLSPY CLASS DEFINITION
  * ========================== */

    function ScrollSpy(element, options) {
        var process = $.proxy(process, this),
            $element = $(element).is('body') ? $(window) : $(element),
            href;
        options = $.extend({}, $.fn.scrollspy.defaults, options);
        $scrollElement = $element.on('scroll.scroll-spy.data-api', process);
        selector = (options.target
            || ((href = $(element).attr('href')) && href.replace(/.*(?=#[^\s]+$)/, '')) //strip for ie7
            || '') + ' .nav li > a';
        $body = $('body');
        refresh();
        process();
    }

    ScrollSpy.prototype = {
        constructor: ScrollSpy,
        refresh: function() {
            var self = this, $targets;
            offsets = $([]);
            targets = $([]);
            $targets = $body
                .find(selector)
                .map(function() {
                    var $el = $(this),
                        href = $el.data('target') || $el.attr('href'),
                        $href = /^#\w/.test(href) && $(href);
                    return ($href
                        && $href.length
                        && [[$href.position().top + (!$.isWindow(self.$scrollElement.get(0)) && self.$scrollElement.scrollTop()), href]]) || null;
                })
                .sort(function(a, b) { return a[0] - b[0]; })
                .each(function() {
                    self.offsets.push(this[0]);
                    self.targets.push(this[1]);
                });
        },
        process: function() {
            var scrollTop = $scrollElement.scrollTop() + options.offset,
                scrollHeight = $scrollElement[0].scrollHeight || $body[0].scrollHeight,
                maxScroll = scrollHeight - $scrollElement.height(),
                offsets = offsets,
                targets = targets,
                activeTarget = activeTarget,
                i;
            if (scrollTop >= maxScroll) {
                return activeTarget != (i = targets.last()[0])
                    && activate(i);
            }

            for (i = offsets.length; i--;) {
                activeTarget != targets[i]
                    && scrollTop >= offsets[i]
                    && (!offsets[i + 1] || scrollTop <= offsets[i + 1])
                    && activate(targets[i]);
            }
        },
        activate: function(target) {
            var active, selector;
            activeTarget = target;
            $(selector)
                .parent('.active')
                .removeClass('active');
            selector = selector
                + '[data-target="' + target + '"],'
                + selector + '[href="' + target + '"]';
            active = $(selector)
                .parent('li')
                .addClass('active');
            if (active.parent('.dropdown-menu').length) {
                active = active.closest('li.dropdown').addClass('active');
            }

            active.trigger('activate');
        }
    }; /* SCROLLSPY PLUGIN DEFINITION
  * =========================== */

    var old = $.fn.scrollspy;
    $.fn.scrollspy = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('scrollspy'),
                options = typeof option == 'object' && option;
            if (!data) $data('scrollspy', (data = new ScrollSpy(this, options)));
            if (typeof option == 'string') data[option]();
        });
    };
    $.fn.scrollspy.Constructor = ScrollSpy;
    $.fn.scrollspy.defaults = {
        offset: 10
    }; /* SCROLLSPY NO CONFLICT
  * ===================== */

    $.fn.scrollspy.noConflict = function() {
        $.fn.scrollspy = old;
        return this;
    }; /* SCROLLSPY DATA-API
  * ================== */

    $(window).on('load', function() {
        $('[data-spy="scroll"]').each(function() {
            var $spy = $(this);
            $spy.scrollspy($spy.data());
        });
    });
}(window.jQuery);
/* ========================================================
 * bootstrap-tab.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#tabs
 * ========================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ======================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* TAB CLASS DEFINITION
  * ==================== */

    var Tab = function(element) {
        element = $(element);
    };
    Tab.prototype = {
        constructor: Tab,
        show: function() {
            var $this = element,
                $ul = $closest('ul:not(.dropdown-menu)'),
                selector = $attr('data-target'),
                previous,
                $target,
                e;
            if (!selector) {
                selector = $attr('href');
                selector = selector && selector.replace(/.*(?=#[^\s]*$)/, ''); //strip for ie7
            }

            if ($parent('li').hasClass('active')) return;
            previous = $ul.find('.active:last a')[0];
            e = $.Event('show', {
                relatedTarget: previous
            });
            $trigger(e);
            if (e.isDefaultPrevented()) return;
            $target = $(selector);
            activate($parent('li'), $ul);
            activate($target, $target.parent(), function() {
                $trigger({
                    type: 'shown',
                    relatedTarget: previous
                });
            });
        },
        activate: function(element, container, callback) {
            var $active = container.find('* > .active'),
                transition = callback
                    && $.support.transition
                    && $active.hasClass('fade');

            function next() {
                $active
                    .removeClass('active')
                    .find('* > .dropdown-menu > .active')
                    .removeClass('active');
                element.addClass('active');
                if (transition) {
                    element[0].offsetWidth; // reflow for transition
                    element.addClass('in');
                } else {
                    element.removeClass('fade');
                }

                if (element.parent('.dropdown-menu')) {
                    element.closest('li.dropdown').addClass('active');
                }

                callback && callback();
            }

            transition ?
                $active.one($.support.transition.end, next) :
                next();
            $active.removeClass('in');
        }
    }; /* TAB PLUGIN DEFINITION
  * ===================== */

    var old = $.fn.tab;
    $.fn.tab = function(option) {
        return each(function() {
            var $this = $(this), data = $data('tab');
            if (!data) $data('tab', (data = new Tab(this)));
            if (typeof option == 'string') data[option]();
        });
    };
    $.fn.tab.Constructor = Tab; /* TAB NO CONFLICT
  * =============== */

    $.fn.tab.noConflict = function() {
        $.fn.tab = old;
        return this;
    }; /* TAB DATA-API
  * ============ */

    $(document).on('click.tab.data-api', '[data-toggle="tab"], [data-toggle="pill"]', function(e) {
        e.preventDefault();
        $(this).tab('show');
    });
}(window.jQuery);
/* ==========================================================
 * bootstrap-affix.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#affix
 * ==========================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* AFFIX CLASS DEFINITION
  * ====================== */

    var Affix = function(element, options) {
        options = $.extend({}, $.fn.affix.defaults, options);
        $window = $(window)
            .on('scroll.affix.data-api', $.proxy(checkPosition, this))
            .on('click.affix.data-api', $.proxy(function() { setTimeout($.proxy(checkPosition, this), 1); }, this));
        $element = $(element);
        checkPosition();
    };
    Affix.prototype.checkPosition = function() {
        if (!$element.is(':visible')) return;
        var scrollHeight = $(document).height(),
            scrollTop = $window.scrollTop(),
            position = $element.offset(),
            offset = options.offset,
            offsetBottom = offset.bottom,
            offsetTop = offset.top,
            reset = 'affix affix-top affix-bottom',
            affix;
        if (typeof offset != 'object') offsetBottom = offsetTop = offset;
        if (typeof offsetTop == 'function') offsetTop = offset.top();
        if (typeof offsetBottom == 'function') offsetBottom = offset.bottom();
        affix = unpin != null && (scrollTop + unpin <= position.top) ?
            false : offsetBottom != null && (position.top + $element.height() >= scrollHeight - offsetBottom) ?
            'bottom' : offsetTop != null && scrollTop <= offsetTop ?
            'top' : false;
        if (affixed === affix) return;
        affixed = affix;
        unpin = affix == 'bottom' ? position.top - scrollTop : null;
        $element.removeClass(reset).addClass('affix' + (affix ? '-' + affix : ''));
    }; /* AFFIX PLUGIN DEFINITION
  * ======================= */

    var old = $.fn.affix;
    $.fn.affix = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('affix'),
                options = typeof option == 'object' && option;
            if (!data) $data('affix', (data = new Affix(this, options)));
            if (typeof option == 'string') data[option]();
        });
    };
    $.fn.affix.Constructor = Affix;
    $.fn.affix.defaults = {
        offset: 0
    }; /* AFFIX NO CONFLICT
  * ================= */

    $.fn.affix.noConflict = function() {
        $.fn.affix = old;
        return this;
    }; /* AFFIX DATA-API
  * ============== */

    $(window).on('load', function() {
        $('[data-spy="affix"]').each(function() {
            var $spy = $(this), data = $spy.data();
            data.offset = data.offset || {};
            data.offsetBottom && (data.offset.bottom = data.offsetBottom);
            data.offsetTop && (data.offset.top = data.offsetTop);
            $spy.affix(data);
        });
    });
}(window.jQuery);
/* ==========================================================
 * bootstrap-alert.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#alerts
 * ==========================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* ALERT CLASS DEFINITION
  * ====================== */

    var dismiss = '[data-dismiss="alert"]',
        Alert = function(el) {
            $(el).on('click', dismiss, close);
        };
    Alert.prototype.close = function(e) {
        var $this = $(this),
            selector = $attr('data-target'),
            $parent;
        if (!selector) {
            selector = $attr('href');
            selector = selector && selector.replace(/.*(?=#[^\s]*$)/, ''); //strip for ie7
        }

        $parent = $(selector);
        e && e.preventDefault();
        $parent.length || ($parent = $hasClass('alert') ? $this : $parent());
        $parent.trigger(e = $.Event('close'));
        if (e.isDefaultPrevented()) return;
        $parent.removeClass('in');

        function removeElement() {
            $parent
                .trigger('closed')
                .remove();
        }

        $.support.transition && $parent.hasClass('fade') ?
            $parent.on($.support.transition.end, removeElement) :
            removeElement();
    }; /* ALERT PLUGIN DEFINITION
  * ======================= */

    var old = $.fn.alert;
    $.fn.alert = function(option) {
        return each(function() {
            var $this = $(this), data = $data('alert');
            if (!data) $data('alert', (data = new Alert(this)));
            if (typeof option == 'string') data[option].call($this);
        });
    };
    $.fn.alert.Constructor = Alert; /* ALERT NO CONFLICT
  * ================= */

    $.fn.alert.noConflict = function() {
        $.fn.alert = old;
        return this;
    }; /* ALERT DATA-API
  * ============== */

    $(document).on('click.alert.data-api', dismiss, Alert.prototype.close);
}(window.jQuery);
/* ============================================================
 * bootstrap-button.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#buttons
 * ============================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */

!function($) {
    "use strict"; // jshint ;_;

    /* BUTTON PUBLIC CLASS DEFINITION
  * ============================== */

    var Button = function(element, options) {
        $element = $(element);
        options = $.extend({}, $.fn.button.defaults, options);
    };
    Button.prototype.setState = function(state) {
        var d = 'disabled',
            $el = $element,
            data = $el.data(),
            val = $el.is('input') ? 'val' : 'html';
        state = state + 'Text';
        data.resetText || $el.data('resetText', $el[val]());
        $el[val](data[state] || options[state]); // push to event loop to allow forms to submit
        setTimeout(function() {
            state == 'loadingText' ?
                $el.addClass(d).attr(d, d) :
                $el.removeClass(d).removeAttr(d);
        }, 0);
    };
    Button.prototype.toggle = function() {
        var $parent = $element.closest('[data-toggle="buttons-radio"]');
        $parent && $parent
            .find('.active')
            .removeClass('active');
        $element.toggleClass('active');
    }; /* BUTTON PLUGIN DEFINITION
  * ======================== */

    var old = $.fn.button;
    $.fn.button = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('button'),
                options = typeof option == 'object' && option;
            if (!data) $data('button', (data = new Button(this, options)));
            if (option == 'toggle') data.toggle();
            else if (option) data.setState(option);
        });
    };
    $.fn.button.defaults = {
        loadingText: 'loading...'
    };
    $.fn.button.Constructor = Button; /* BUTTON NO CONFLICT
  * ================== */

    $.fn.button.noConflict = function() {
        $.fn.button = old;
        return this;
    }; /* BUTTON DATA-API
  * =============== */

    $(document).on('click.button.data-api', '[data-toggle^=button]', function(e) {
        var $btn = $(e.target);
        if (!$btn.hasClass('btn')) $btn = $btn.closest('.btn');
        $btn.button('toggle');
    });
}(window.jQuery);
/* =============================================================
 * bootstrap-collapse.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#collapse
 * =============================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */

!function($) {
    "use strict"; // jshint ;_;

    /* COLLAPSE PUBLIC CLASS DEFINITION
  * ================================ */

    var Collapse = function(element, options) {
        $element = $(element);
        options = $.extend({}, $.fn.collapse.defaults, options);
        if (options.parent) {
            $parent = $(options.parent);
        }

        options.toggle && toggle();
    };
    Collapse.prototype = {
        constructor: Collapse,
        dimension: function() {
            var hasWidth = $element.hasClass('width');
            return hasWidth ? 'width' : 'height';
        },
        show: function() {
            var dimension,
                scroll,
                actives,
                hasData;
            if (transitioning || $element.hasClass('in')) return;
            dimension = dimension();
            scroll = $.camelCase(['scroll', dimension].join('-'));
            actives = $parent && $parent.find('* > .accordion-group > .in');
            if (actives && actives.length) {
                hasData = actives.data('collapse');
                if (hasData && hasData.transitioning) return;
                actives.collapse('hide');
                hasData || actives.data('collapse', null);
            }

            $element[dimension](0);
            transition('addClass', $.Event('show'), 'shown');
            $.support.transition && $element[dimension]($element[0][scroll]);
        },
        hide: function() {
            var dimension;
            if (transitioning || !$element.hasClass('in')) return;
            dimension = dimension();
            reset($element[dimension]());
            transition('removeClass', $.Event('hide'), 'hidden');
            $element[dimension](0);
        },
        reset: function(size) {
            var dimension = dimension();
            $element
                .removeClass('collapse')
                [dimension](size || 'auto')
                [0].offsetWidth;
            $element[size !== null ? 'addClass' : 'removeClass']('collapse');
            return this;
        },
        transition: function(method, startEvent, completeEvent) {
            var that = this,
                complete = function() {
                    if (startEvent.type == 'show') that.reset();
                    that.transitioning = 0;
                    that.$element.trigger(completeEvent);
                };
            $element.trigger(startEvent);
            if (startEvent.isDefaultPrevented()) return;
            transitioning = 1;
            $element[method]('in');
            $.support.transition && $element.hasClass('collapse') ?
                $element.one($.support.transition.end, complete) :
                complete();
        },
        toggle: function() {
            this[$element.hasClass('in') ? 'hide' : 'show']();
        }
    }; /* COLLAPSE PLUGIN DEFINITION
  * ========================== */

    var old = $.fn.collapse;
    $.fn.collapse = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('collapse'),
                options = $.extend({}, $.fn.collapse.defaults, $data(), typeof option == 'object' && option);
            if (!data) $data('collapse', (data = new Collapse(this, options)));
            if (typeof option == 'string') data[option]();
        });
    };
    $.fn.collapse.defaults = {
        toggle: true
    };
    $.fn.collapse.Constructor = Collapse; /* COLLAPSE NO CONFLICT
  * ==================== */

    $.fn.collapse.noConflict = function() {
        $.fn.collapse = old;
        return this;
    }; /* COLLAPSE DATA-API
  * ================= */

    $(document).on('click.collapse.data-api', '[data-toggle=collapse]', function(e) {
        var $this = $(this),
            href,
            target = $attr('data-target')
                || e.preventDefault()
                || (href = $attr('href')) && href.replace(/.*(?=#[^\s]+$)/, '') //strip for ie7
            ,
            option = $(target).data('collapse') ? 'toggle' : $data();
        $this[$(target).hasClass('in') ? 'addClass' : 'removeClass']('collapsed');
        $(target).collapse(option);
    });
}(window.jQuery);
/* ==========================================================
 * bootstrap-carousel.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#carousel
 * ==========================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */

!function($) {
    "use strict"; // jshint ;_;

    /* CAROUSEL CLASS DEFINITION
  * ========================= */

    var Carousel = function(element, options) {
        $element = $(element);
        $indicators = $element.find('.carousel-indicators');
        options = options;
        options.pause == 'hover' && $element
            .on('mouseenter', $.proxy(pause, this))
            .on('mouseleave', $.proxy(cycle, this));
    };
    Carousel.prototype = {
        cycle: function(e) {
            if (!e) paused = false;
            if (interval) clearInterval(interval);
            options.interval
                && !paused
                && (interval = setInterval($.proxy(next, this), options.interval));
            return this;
        },
        getActiveIndex: function() {
            $active = $element.find('.item.active');
            $items = $active.parent().children();
            return $items.index($active);
        },
        to: function(pos) {
            var activeIndex = getActiveIndex(), that = this;
            if (pos > ($items.length - 1) || pos < 0) return;
            if (sliding) {
                return $element.one('slid', function() {
                    that.to(pos);
                });
            }

            if (activeIndex == pos) {
                return pause().cycle();
            }

            return slide(pos > activeIndex ? 'next' : 'prev', $($items[pos]));
        },
        pause: function(e) {
            if (!e) paused = true;
            if ($element.find('.next, .prev').length && $.support.transition.end) {
                $element.trigger($.support.transition.end);
                cycle();
            }
            clearInterval(interval);
            interval = null;
            return this;
        },
        next: function() {
            if (sliding) return;
            return slide('next');
        },
        prev: function() {
            if (sliding) return;
            return slide('prev');
        },
        slide: function(type, next) {
            var $active = $element.find('.item.active'),
                $next = next || $active[type](),
                isCycling = interval,
                direction = type == 'next' ? 'left' : 'right',
                fallback = type == 'next' ? 'first' : 'last',
                that = this,
                e;
            sliding = true;
            isCycling && pause();
            $next = $next.length ? $next : $element.find('.item')[fallback]();
            e = $.Event('slide', {
                relatedTarget: $next[0],
                direction: direction
            });
            if ($next.hasClass('active')) return;
            if ($indicators.length) {
                $indicators.find('.active').removeClass('active');
                $element.one('slid', function() {
                    var $nextIndicator = $(that.$indicators.children()[that.getActiveIndex()]);
                    $nextIndicator && $nextIndicator.addClass('active');
                });
            }

            if ($.support.transition && $element.hasClass('slide')) {
                $element.trigger(e);
                if (e.isDefaultPrevented()) return;
                $next.addClass(type);
                $next[0].offsetWidth; // force reflow
                $active.addClass(direction);
                $next.addClass(direction);
                $element.one($.support.transition.end, function() {
                    $next.removeClass([type, direction].join(' ')).addClass('active');
                    $active.removeClass(['active', direction].join(' '));
                    that.sliding = false;
                    setTimeout(function() { that.$element.trigger('slid'); }, 0);
                });
            } else {
                $element.trigger(e);
                if (e.isDefaultPrevented()) return;
                $active.removeClass('active');
                $next.addClass('active');
                sliding = false;
                $element.trigger('slid');
            }

            isCycling && cycle();
            return this;
        }
    }; /* CAROUSEL PLUGIN DEFINITION
  * ========================== */

    var old = $.fn.carousel;
    $.fn.carousel = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('carousel'),
                options = $.extend({}, $.fn.carousel.defaults, typeof option == 'object' && option),
                action = typeof option == 'string' ? option : options.slide;
            if (!data) $data('carousel', (data = new Carousel(this, options)));
            if (typeof option == 'number') data.to(option);
            else if (action) data[action]();
            else if (options.interval) data.pause().cycle();
        });
    };
    $.fn.carousel.defaults = {
        interval: 5000,
        pause: 'hover'
    };
    $.fn.carousel.Constructor = Carousel; /* CAROUSEL NO CONFLICT
  * ==================== */

    $.fn.carousel.noConflict = function() {
        $.fn.carousel = old;
        return this;
    }; /* CAROUSEL DATA-API
  * ================= */

    $(document).on('click.carousel.data-api', '[data-slide], [data-slide-to]', function(e) {
        var $this = $(this),
            href,
            $target = $($attr('data-target') || (href = $attr('href')) && href.replace(/.*(?=#[^\s]+$)/, '')) //strip for ie7
            ,
            options = $.extend({}, $target.data(), $data()),
            slideIndex;
        $target.carousel(options);
        if (slideIndex = $attr('data-slide-to')) {
            $target.data('carousel').pause().to(slideIndex).cycle();
        }

        e.preventDefault();
    });
}(window.jQuery);
/* =============================================================
 * bootstrap-typeahead.js v2.3.0
 * http://twitter.github.com/bootstrap/javascript.html#typeahead
 * =============================================================
 * Copyright 2012 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */

!function($) {
    "use strict"; // jshint ;_;

    /* TYPEAHEAD PUBLIC CLASS DEFINITION
  * ================================= */

    var Typeahead = function(element, options) {
        $element = $(element);
        options = $.extend({}, $.fn.typeahead.defaults, options);
        matcher = options.matcher || matcher;
        sorter = options.sorter || sorter;
        highlighter = options.highlighter || highlighter;
        updater = options.updater || updater;
        source = options.source;
        $menu = $(options.menu);
        shown = false;
        listen();
    };
    Typeahead.prototype = {
        constructor: Typeahead,
        select: function() {
            var val = $menu.find('.active').attr('data-value');
            $element
                .val(updater(val))
                .change();
            return hide();
        },
        updater: function(item) {
            return item;
        },
        show: function() {
            var pos = $.extend({}, $element.position(), {
                height: $element[0].offsetHeight
            });
            $menu
                .insertAfter($element)
                .css({
                    top: pos.top + pos.height,
                    left: pos.left
                })
                .show();
            shown = true;
            return this;
        },
        hide: function() {
            $menu.hide();
            shown = false;
            return this;
        },
        lookup: function(event) {
            var items;
            query = $element.val();
            if (!query || query.length < options.minLength) {
                return shown ? hide() : this;
            }

            items = $.isFunction(source) ? source(query, $.proxy(process, this)) : source;
            return items ? process(items) : this;
        },
        process: function(items) {
            var that = this;
            items = $.grep(items, function(item) {
                return that.matcher(item);
            });
            items = sorter(items);
            if (!items.length) {
                return shown ? hide() : this;
            }

            return render(items.slice(0, options.items)).show();
        },
        matcher: function(item) {
            return ~item.toLowerCase().indexOf(query.toLowerCase());
        },
        sorter: function(items) {
            var beginswith = [],
                caseSensitive = [],
                caseInsensitive = [],
                item;
            while (item = items.shift()) {
                if (!item.toLowerCase().indexOf(query.toLowerCase())) beginswith.push(item);
                else if (~item.indexOf(query)) caseSensitive.push(item);
                else caseInsensitive.push(item);
            }

            return beginswith.concat(caseSensitive, caseInsensitive);
        },
        highlighter: function(item) {
            var query = query.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, '\\$&');
            return item.replace(new RegExp('(' + query + ')', 'ig'), function($1, match) {
                return '<strong>' + match + '</strong>';
            });
        },
        render: function(items) {
            var that = this;
            items = $(items).map(function(i, item) {
                i = $(that.options.item).attr('data-value', item);
                i.find('a').html(that.highlighter(item));
                return i[0];
            });
            items.first().addClass('active');
            $menu.html(items);
            return this;
        },
        next: function(event) {
            var active = $menu.find('.active').removeClass('active'), next = active.next();
            if (!next.length) {
                next = $($menu.find('li')[0]);
            }

            next.addClass('active');
        },
        prev: function(event) {
            var active = $menu.find('.active').removeClass('active'), prev = active.prev();
            if (!prev.length) {
                prev = $menu.find('li').last();
            }

            prev.addClass('active');
        },
        listen: function() {
            $element
                .on('focus', $.proxy(focus, this))
                .on('blur', $.proxy(blur, this))
                .on('keypress', $.proxy(keypress, this))
                .on('keyup', $.proxy(keyup, this));
            if (eventSupported('keydown')) {
                $element.on('keydown', $.proxy(keydown, this));
            }

            $menu
                .on('click', $.proxy(click, this))
                .on('mouseenter', 'li', $.proxy(mouseenter, this))
                .on('mouseleave', 'li', $.proxy(mouseleave, this));
        },
        eventSupported: function(eventName) {
            var isSupported = eventName in $element;
            if (!isSupported) {
                $element.setAttribute(eventName, 'return;');
                isSupported = typeof $element[eventName] === 'function';
            }
            return isSupported;
        },
        move: function(e) {
            if (!shown) return;
            switch (e.keyCode) {
            case 9: // tab
            case 13: // enter
            case 27: // escape
                e.preventDefault();
                break;
            case 38: // up arrow
                e.preventDefault();
                prev();
                break;
            case 40: // down arrow
                e.preventDefault();
                next();
                break;
            }

            e.stopPropagation();
        },
        keydown: function(e) {
            suppressKeyPressRepeat = ~$.inArray(e.keyCode, [40, 38, 9, 13, 27]);
            move(e);
        },
        keypress: function(e) {
            if (suppressKeyPressRepeat) return;
            move(e);
        },
        keyup: function(e) {
            switch (e.keyCode) {
            case 40: // down arrow
            case 38: // up arrow
            case 16: // shift
            case 17: // ctrl
            case 18: // alt
                break;
            case 9: // tab
            case 13: // enter
                if (!shown) return;
                select();
                break;
            case 27: // escape
                if (!shown) return;
                hide();
                break;
            default:
                lookup();
            }

            e.stopPropagation();
            e.preventDefault();
        },
        focus: function(e) {
            focused = true;
        },
        blur: function(e) {
            focused = false;
            if (!mousedover && shown) hide();
        },
        click: function(e) {
            e.stopPropagation();
            e.preventDefault();
            select();
            $element.focus();
        },
        mouseenter: function(e) {
            mousedover = true;
            $menu.find('.active').removeClass('active');
            $(e.currentTarget).addClass('active');
        },
        mouseleave: function(e) {
            mousedover = false;
            if (!focused && shown) hide();
        }
    }; /* TYPEAHEAD PLUGIN DEFINITION
   * =========================== */

    var old = $.fn.typeahead;
    $.fn.typeahead = function(option) {
        return each(function() {
            var $this = $(this),
                data = $data('typeahead'),
                options = typeof option == 'object' && option;
            if (!data) $data('typeahead', (data = new Typeahead(this, options)));
            if (typeof option == 'string') data[option]();
        });
    };
    $.fn.typeahead.defaults = {
        source: [],
        items: 8,
        menu: '<ul class="typeahead dropdown-menu"></ul>',
        item: '<li><a href="#"></a></li>',
        minLength: 1
    };
    $.fn.typeahead.Constructor = Typeahead; /* TYPEAHEAD NO CONFLICT
  * =================== */

    $.fn.typeahead.noConflict = function() {
        $.fn.typeahead = old;
        return this;
    }; /* TYPEAHEAD DATA-API
  * ================== */

    $(document).on('focus.typeahead.data-api', '[data-provide="typeahead"]', function(e) {
        var $this = $(this);
        if ($data('typeahead')) return;
        $typeahead($data());
    });
}(window.jQuery);