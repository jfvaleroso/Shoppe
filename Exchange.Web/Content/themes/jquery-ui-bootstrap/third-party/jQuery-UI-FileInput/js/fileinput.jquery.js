/**
 * --------------------------------------------------------------------
 * jQuery customfileinput plugin
 * Author: Scott Jehl, scott@filamentgroup.com
 * Copyright (c) 2009 Filament Group. Updated 2012.
 * licensed under MIT (filamentgroup.com/examples/mit-license.txt)
 * --------------------------------------------------------------------
 */

/**
 * All credits go to the Author of this file, some additional customization was
 * done for theme compat. purposes.
 *
 * Additional bugfixes/changes by smurfy
 */
!function($) {
    "use strict"; // jshint ;_;

    /* FILEINPUT CLASS DEFINITION
     * ====================== */

    var CustomFileInput = function(content, options) {
        var self = this;
        $element = $(content);

        options = $.extend({
            classes: ($element.attr('class') ? $element.attr('class') : ''),
        }, options);

        //create custom control container
        $upload = $('<div class="input-' + (('right' === options.button_position) ? 'append' : 'prepend') + ' customfile">');
        //create custom control feedback
        $uploadFeedback = $('<input type="text" readonly="readonly" class="customfile-feedback ' + options.classes + '" aria-hidden="true" value="' + options.feedback_text + '"/>').appendTo($upload);
        //create custom control button
        $uploadButton = $('<span class="add-on customfile-button" aria-hidden="true">' + options.button_text + '</span>').css({ float: options.button_position });

        $element
            .addClass('customfile-input') //add class for CSS
            .on('focus', $.proxy(onFocus, this))
            .on('blur', $.proxy(onBlur, this))
            .on('disable', $.proxy(onDisable, this))
            .on('enable', $.proxy(onEnable, this))
            .on('checkChange', $.proxy(onCheckChange, this))
            .on('change', $.proxy(onChange, this))
            .on('click', $.proxy(onClick, this));

        if ('right' === options.button_position) {
            $uploadButton.insertAfter($uploadFeedback);
        } else {
            $uploadButton.insertBefore($uploadFeedback);
        }

        //match disabled state
        if ($element.is('[disabled]')) {
            $element.trigger('disable');
        } else {
            $upload.on('click', function() { self.$element.trigger('click'); });
        }

        //insert original input file in dom, css if hide it outside of screen
        $upload.insertAfter($element);
        $element.insertAfter($upload);
    };

    CustomFileInput.prototype = {
        constructor: CustomFileInput,

        onClick: function() {
            var self = this;
            $element.data('val', $element.val());
            setTimeout(function() {
                self.$element.trigger('checkChange');
            }, 100);
        },

        onCheckChange: function() {
            if ($element.val() && $element.val() != $element.data('val')) {
                $element.trigger('change');
            }
        },

        onEnable: function() {
            $element.removeAttr('disabled');
            $upload.removeClass('customfile-disabled');
        },

        onDisable: function() {
            $element.attr('disabled', true);
            $upload.addClass('customfile-disabled');
        },

        onFocus: function() {
            $upload.addClass('customfile-focus');
            $element.data('val', $element.val());
        },

        onBlur: function() {
            $upload.removeClass('customfile-focus');
            $element.trigger('checkChange');
        },

        onChange: function() {
            //get file name
            var fileName = $element.val().split(/\\/).pop();
            if (!fileName) {
                $uploadFeedback
                    .val(options.feedback_text) //set feedback text to filename
                    .removeClass('customfile-feedback-populated'); //add class to show populated state
                $uploadButton.text(options.button_text);
            } else {
                $uploadFeedback
                    .val(fileName) //set feedback text to filename
                    .addClass('customfile-feedback-populated'); //add class to show populated state
                $uploadButton.text(options.button_change_text);
            }
        }
    };

    $.fn.customFileInput = function(option) {
        return each(function() {
            var $this = $(this);
            var data = $data('customFileInput');
            var options = $.extend({}, $.fn.customFileInput.defaults, $data(), typeof option == 'object' && option);
            if (!data) {
                $data('customFileInput', (data = new CustomFileInput(this, options)));
            }
        });
    };

    $.fn.customFileInput.defaults = {
        button_position: 'right',
        feedback_text: 'No file selected...',
        button_text: 'Browse',
        button_change_text: 'Change'
    };
}(window.jQuery);