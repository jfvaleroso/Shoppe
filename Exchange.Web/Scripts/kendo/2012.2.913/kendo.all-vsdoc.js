﻿var kendo = {
    ui: {},
    mobile: { ui: {} },
    dataviz: { ui: {} }
};

FX = function() {};

FX.prototype = {
    kendoAnimate: function(effects, duration, reverse, complete, show, hide) {
        /// <summary>
        ///     Applies the specified animation effect/s to all selected elements and triggers the callback on every element when
        ///     it completes its animation.
        ///     Uses transitions and transformations where available and falls back to jQuery animate where not. kendoAnimate can
        ///     be used to run one of the provided
        ///     animation effects or you can define one yourself, using the same format.
        /// </summary>
        /// <param name="effects" type="String|Object">
        ///     The effect/s that should be executed on the selected elements. Can be one or
        ///     several combined effects, specified as a string with format "effect:direction effect:direction". Transformation
        ///     effects that animate the same property can't be combined, like slide:left and slide:right for instance.
        /// </param>
        /// <param name="duration" type="Number">The effect duration (speed) in milliseconds.</param>
        /// <param name="reverse" type="Boolean">
        ///     Whether the effect should play backwards, useful when doing the same animation but
        ///     with the opposite direction, like opening and closing.
        /// </param>
        /// <param name="complete" type="Function">
        ///     Completion callback that should be called after animation completion. It gets
        ///     fired for every animated element and is passed the said element as its only argument.
        /// </param>
        /// <param name="show" type="Boolean">Whether the element should be shown before animating.</param>
        /// <param name="hide" type="Boolean">Whether the element should be hidden after the animation completes.</param>
    },

    kendoStop: function(clearQueue, gotoEnd) {
        /// <summary>
        ///     Stops the animation effect running on the specified elements and optionally jumps to the end and clears the
        ///     animation effect queue.
        ///     In browsers that don't support transitions falls back to jQuery stop().elements.kendoStop(clearQueue, gotoEnd);This
        ///     functionality is useful to avoid chaining many effects, causing them to run longer than expected.
        /// </summary>
        /// <param name="clearQueue" type="Boolean">Whether to clear the animation effects queue and start anew.</param>
        /// <param name="gotoEnd" type="Boolean">
        ///     Whether to jump to the animation end position when stopping or just leave the
        ///     element at its current position.
        /// </param>
    },

    kendoAddClass: function() {
        /// <summary>
        ///     Adds a CSS class to the element, while doing a transition to the new state. If the browser doesn't support
        ///     transitions,
        ///     the method falls back to jQuery addClass();> **Important:** kendoAddClass doesn't add the animation to the
        ///     animation effect queue and can't be stopped with kendoStop.elements.kendoAddClass(classes, options);
        /// </summary>
    },

    kendoRemoveClass: function() {
        /// <summary>
        ///     Removes a CSS class from the element, while doing a transition to the new state. If the browser doesn't support
        ///     transitions,
        ///     the method falls back to jQuery removeClass();> **Important:** kendoRemoveClass doesn't add the animation to the
        ///     animation effect queue and can't be stopped with kendoStop.elements.kendoRemoveClass(classes, options);
        /// </summary>
    },

    kendoToggleClass: function() {
        /// <summary>
        ///     Toggle a CSS class on the element, based on a flag, while doing a transition to the new state. If the browser
        ///     doesn't support transitions,
        ///     the method falls back to jQuery toggleClass();> **Important:** kendoToggleClass doesn't add the animation to the
        ///     animation effect queue and can't be stopped with kendoStop.elements.kendoToggleClass(classes, options, toggle);
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getFX = function() {
    /// <summary>
    ///     Returns a reference to the FX widget, instantiated on the selector.
    /// </summary>
    /// <returns type="FX">The FX instance (if present).</returns>
};

$.fn.FX = function(options) {
    /// <summary>
    ///     Instantiates a FX widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo = {};

kendo.Drag = function() {};

kendo.Drag.prototype = {
    cancel: function() {
        /// <summary>
        ///     Discard the current drag. Calling the `cancel` method will trigger the `cancel` event.
        ///     The correct moment to call this method would be in the `start` event handler.
        /// </summary>
    },

    capture: function() {
        /// <summary>
        ///     Capture the current drag, so that Drag listeners bound to parent elements will not trigger.
        ///     This method will not have any effect if the current drag instance is instantiated with the `global` option set to
        ///     true.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDrag = function() {
    /// <summary>
    ///     Returns a reference to the kendo.Drag widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.Drag">The kendo.Drag instance (if present).</returns>
};

$.fn.kendoDrag = function(options) {
    /// <summary>
    ///     Instantiates a kendo.Drag widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;allowSelection — Boolean (default: false)
    ///     &#10;If set to true, the mousedown and selectstart events will not be prevented.
    ///     &#10;
    ///     &#10;filter — Selector undefined
    ///     &#10;If passed, the filter limits the child elements that will trigger the event sequence.
    ///     &#10;
    ///     &#10;global — Boolean (default: false)
    ///     &#10;If set to true, the drag event will be tracked beyond the element boundaries.
    ///     &#10;
    ///     &#10;stopPropagation — Boolean (default: false)
    ///     &#10;If set to true, the mousedown event propagation will stopped, disabling
    ///     &#10;drag capturing at parent elements.
    ///     &#10;If set to false, dragging outside of the element boundaries will trigger the `end` event.
    ///     &#10;
    ///     &#10;surface — Element undefined
    ///     &#10;If set, the drag event will be tracked for the surface boundaries. By default, leaving the element boundaries
    ///     will end the drag.
    ///     &#10;
    ///     &#10;threshold — Number (default: 0)
    ///     &#10;The minimum distance the mouse/touch should move before the event is triggered.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.DragAxis = function() {};

kendo.DragAxis.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDragAxis = function() {
    /// <summary>
    ///     Returns a reference to the kendo.DragAxis widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.DragAxis">The kendo.DragAxis instance (if present).</returns>
};

$.fn.kendoDragAxis = function(options) {
    /// <summary>
    ///     Instantiates a kendo.DragAxis widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.DataSource = function() {};

kendo.data.DataSource.prototype = {
    add: function() {
        /// <summary>
        ///     Adds a new data item to the DataSource.
        /// </summary>
        /// <returns type="kendo.data.Model">The instance which has been added.</returns>
    },

    aggregate: function(val) {
        /// <summary>
        ///     Get current aggregate descriptors or applies aggregates to the data.
        /// </summary>
        /// <param name="val" type="Object|Array">Aggregate(s) to be applied to the data.</param>
        /// <returns type="Array">Current aggregate descriptors</returns>
    },

    aggregates: function() {
        /// <summary>
        ///     Get result of aggregates calculation
        /// </summary>
        /// <returns type="Array">Aggregates result</returns>
    },

    at: function(index) {
        /// <summary>
        ///     Returns the data item at the specified index.
        /// </summary>
        /// <param name="index" type="Number">The zero-based index of the data item.</param>
        /// <returns type="kendo.data.ObservableObject | kendo.data.Model">The type depends on the schema.</returns>
    },

    cancelChanges: function() {
        /// <summary>
        ///     Cancel the changes made to the DataSource after the last sync. Any changes currently existing in the model
        ///     will be discarded.
        /// </summary>
    },

    data: function(value) {
        /// <summary>
        ///     Gets or sets the data of the `DataSource`.
        /// </summary>
        /// <param name="value" type="Array">
        ///     An `Array` of items to set as the current data of the `DataSource`. If omitted the
        ///     current data will be returned.
        /// </param>
        /// <returns type="ObservableArray` the items of the `DataSource"></returns>
    },

    fetch: function(callback) {
        /// <summary>
        ///     Fetches data using the current filter/sort/group/paging information.
        ///     If data is not available and remote operations are enabled data is requested through the transport,
        ///     otherwise operations are executed over the available data.
        /// </summary>
        /// <param name="callback" type="Function">Optional callback which will be executed when the data is ready.</param>
    },

    filter: function(filters) {
        /// <summary>
        ///     Get current filters or filter the data._Supported filter operators/aliases are_:
        /// </summary>
        /// <param name="filters" type="Object|Array">Filter(s) to be applied to the data.</param>
        /// <returns type="Array">The current filter descriptors.</returns>
    },

    get: function(id) {
        /// <summary>
        ///     Retrieves a model instance by given id.
        /// </summary>
        /// <param name="id" type="Number|String">
        ///     The id of the model to be retrieved. The id of the model is defined via
        ///     `schema.model.id`.
        /// </param>
        /// <returns type="kendo.data.Model` the model instance. If not found `undefined">is returned.</returns>
    },

    getByUid: function(uid) {
        /// <summary>
        ///     Retrieves a data item by its [uid](/api/framework/observableobject#uid) field.
        /// </summary>
        /// <param name="uid" type="String">The uid of the item to be retrieved</param>
        /// <returns type="kendo.data.ObservableObject` or `kendo.data.Model` (if `schema.model` is set). If not found `undefined">
        ///     is
        ///     returned.
        /// </returns>
    },

    group: function(groups) {
        /// <summary>
        ///     Get current group descriptors or group the data.
        /// </summary>
        /// <param name="groups" type="Object|Array">Group(s) to be applied to the data.</param>
        /// <returns type="Array">The current group descriptors.</returns>
    },

    insert: function(index) {
        /// <summary>
        ///     Inserts a new data item in the DataSource.
        /// </summary>
        /// <param name="index" type="Number">The zer-based index at which the data item will be inserted</param>
        /// <returns type="kendo.data.Model">The instance which has been inserted.</returns>
    },

    page: function(page) {
        /// <summary>
        ///     Get current page index or request a page with specified index.
        /// </summary>
        /// <param name="page" type="Number">The index of the page to be retrieved</param>
        /// <returns type="Number">Current page index</returns>
    },

    pageSize: function(size) {
        /// <summary>
        ///     Get current pageSize or request a page with specified number of records.
        /// </summary>
        /// <param name="size" type="Number">The of number of records to be retrieved.</param>
        /// <returns type="Number">Current page size</returns>
    },

    query: function(options) {
        /// <summary>
        ///     Executes a query over the data. Available operations are paging, sorting, filtering, grouping.
        ///     If data is not available or remote operations are enabled, data is requested through the transport.
        ///     Otherwise operations are executed over the available data.
        /// </summary>
        /// <param name="options" type="Object">Contains the settings for the operations.</param>
    },

    read: function(data) {
        /// <summary>
        ///     Read data into the DataSource using the `transport.read` setting.
        /// </summary>
        /// <param name="data" type="Object">Optional data to pass to the remote service configured via `transport.read`.</param>
    },

    remove: function(model) {
        /// <summary>
        ///     Remove a given `kendo.data.Model` instance from the DataSource.
        /// </summary>
        /// <param name="model" type="Object">The [kendo.data.Model](/api/framework/model) instance to be removed.</param>
    },

    sort: function(sort) {
        /// <summary>
        ///     Get current sort descriptors or sorts the data.
        /// </summary>
        /// <param name="sort" type="Object | Array">Sort options to be applied to the data</param>
        /// <returns type="Array">the current sort descriptors.</returns>
    },

    sync: function() {
        /// <summary>
        ///     Synchronizes changes through the transport. Any pending CRUD operations will be sent to the server.
        ///     If the DataSource is in **batch** mode, only one call will be made for each type of operation (Create, Update,
        ///     Destroy).
        ///     Otherwise, the DataSource will send one request per item change and change type.
        /// </summary>
    },

    total: function() {
        /// <summary>
        ///     Get the total number of data items.
        /// </summary>
        /// <returns type="Number">the number of data items.</returns>
    },

    totalPages: function() {
        /// <summary>
        ///     Get the number of available pages.
        /// </summary>
        /// <returns type="Number">the available pages.</returns>
    },

    view: function() {
        /// <summary>
        ///     Returns a the current state of the data items - with applied paging, sorting, filtering and grouping.To ensure that
        ///     data is available this method should be use from within `change` event of the DataSource.
        /// </summary>
        /// <returns type="kendo.data.ObservableArary">the data items.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataDataSource = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.DataSource widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.DataSource">The kendo.data.DataSource instance (if present).</returns>
};

$.fn.kendoDataDataSource = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.DataSource widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;aggregate — Array | Object (default: undefined)
    ///     &#10;Sets fields on which initial aggregates should be calculated
    ///     &#10;
    ///     &#10;autoSync — Boolean undefined
    ///     &#10;Enables (*true*) or disables (*false*) the automatic invocation of the sync() method for each change made.
    ///     &#10;
    ///     &#10;batch — Boolean undefined
    ///     &#10;Enables (*true*) or disables (*false*) batch mode.
    ///     &#10;
    ///     &#10;data — Array undefined
    ///     &#10;Specifies the local JavaScript object to use for the data source.
    ///     &#10;
    ///     &#10;filter — Array | Object (default: undefined)
    ///     &#10;Sets initial filter
    ///     &#10;
    ///     &#10;group — Array | Object (default: undefined)
    ///     &#10;Sets initial grouping
    ///     &#10;
    ///     &#10;page — Number (default: undefined)
    ///     &#10;Sets the index of the displayed page of data.
    ///     &#10;
    ///     &#10;pageSize — Number (default: undefined)
    ///     &#10;Sets the number of records which contains a given page of data.
    ///     &#10;
    ///     &#10;schema — Object undefined
    ///     &#10;Set the object responsible for describing the raw data format.
    ///     &#10;
    ///     &#10;serverAggregates — Boolean (default: false)
    ///     &#10;Determines if aggregates are calculated on the server or not. By default aggregates are calculated
    ///     client-side.
    ///     &#10;
    ///     &#10;serverFiltering — Boolean (default: false)
    ///     &#10;Determines if filtering of the data is handled on the server. By default filtering is performed client-side.>
    ///     **Important:** When `serverFiltering` is set to `true` the developer is responsible for filtering the data.By
    ///     default, a filter object is sent to the server with the query string in the following form:*   filter[logic]: and
    ///     &#10;*   filter[filters][0][field]: orderId
    ///     &#10;*   filter[filters][0][operator]: desc
    ///     &#10;*   filter[filters][0][value]: 10248Possible values for **operator** include:
    ///     &#10;
    ///     &#10;serverGrouping — Boolean (default: false)
    ///     &#10;Determines if grouping of the data is handled on the server. By default grouping is performed client-side.>
    ///     **Important:** When `serverGrouping` is set to `true` the developer is responsible for grouping the data.By
    ///     default, a group object is sent to the server with the query string in the following form:*   group[0][field]:
    ///     orderId
    ///     &#10;*   group[0][dir]: descIt is possible to modify these parameters by using the `parameterMap` function found on
    ///     the [transport](#transport-object).
    ///     &#10;
    ///     &#10;serverPaging — Boolean (default: false)
    ///     &#10;Determines if paging of the data is on the server. By default paging is performed client-side. If
    ///     `serverPaging` is enabled the
    ///     &#10;total number of data items should also be returned in the response. Use the `schema.total` setting to
    ///     customize that.> **Important:** When `serverPaging` is set to `true` the developer is responsible for paging the
    ///     data.The following options are sent to the server as part of the query string by default:
    ///     &#10;
    ///     &#10;serverSorting — Boolean (default: false)
    ///     &#10;Determines if sorting of the data should is handled on the server. By default sorting is performed
    ///     client-side.> **Important:** When `serverSorting` is set to `true` the developer is responsible for sorting the
    ///     data.By default, a sort object is sent to the server with the query string in the following form:*
    ///     sort[0][field]: orderId
    ///     &#10;*   sort[0][dir]: ascIt is possible to modify these parameters by using the `parameterMap` function found on
    ///     the [transport](#transport-object).
    ///     &#10;
    ///     &#10;sort — Array | Object (default: undefined)
    ///     &#10;Sets initial sort order
    ///     &#10;
    ///     &#10;transport — Object undefined
    ///     &#10;Specifies the settings for loading and saving data. This can be a remote or local/in-memory data.
    ///     &#10;
    ///     &#10;type — String undefined
    ///     &#10;Loads transport with preconfigured settings. Currently supports only "odata" (Requires kendo.data.odata.js to
    ///     be included).
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.HierarchicalDataSource = function() {};

kendo.data.HierarchicalDataSource.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataHierarchicalDataSource = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.HierarchicalDataSource widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.HierarchicalDataSource">The kendo.data.HierarchicalDataSource instance (if present).</returns>
};

$.fn.kendoDataHierarchicalDataSource = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.HierarchicalDataSource widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.Model = function() {};

kendo.data.Model.prototype = {
    bind: function(eventName, handler) {
        /// <summary>
        ///     Attaches an event handler for the specified event. Inherited from `ObservableObject`. More info can be found in the
        ///     [bind](/api/framework/observableobject#bind) section of the
        ///     ObservableObject API reference.
        /// </summary>
        /// <param name="eventName" type="String">The name of the event.</param>
        /// <param name="handler" type="Function">The function which will be invoked when the event is raised.</param>
    },

    Model: function(options) {
        /// <summary>
        ///     Defines a new `Model` type using the provided options.
        /// </summary>
        /// <param name="options" type="Object">Describes the configuration options of the new model type.</param>
    },

    editable: function(field) {
        /// <summary>
        ///     Determines if the specified field is editable or not.
        /// </summary>
        /// <param name="field" type="String">The field to check.</param>
    },

    get: function() {
        /// <summary>
        ///     Gets the value of the specified field. Inherited from `ObservableObject`. More info can be found in the
        ///     [get](/api/framework/observableobject#get) section of the
        ///     ObservableObject API reference.
        /// </summary>
    },

    isNew: function() {
        /// <summary>
        ///     Checks if the `Model` is new or not. The `id` field is used to determine if a model instance is new or existing
        ///     one.
        ///     If the value of the field specified is equal to the default value (specifed through the `fields` configuration) the
        ///     model is considered as new.
        /// </summary>
    },

    set: function() {
        /// <summary>
        ///     Sets the value of the specified field. Inherited from `ObservableObject`. More info can be found in the
        ///     [set](/api/framework/observableobject#set) section of the
        ///     ObservableObject API reference.
        /// </summary>
    },

    toJSON: function() {
        /// <summary>
        ///     Creates a plain JavaScript object which contains all fields of the `Model`. Inherited from `ObservableObject`. More
        ///     info can be found in the [toJSON](/api/framework/observableobject#tojson) section of the
        ///     ObservableObject API reference.
        /// </summary>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataModel = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.Model widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.Model">The kendo.data.Model instance (if present).</returns>
};

$.fn.kendoDataModel = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.Model widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.Node = function() {};

kendo.data.Node.prototype = {
    append: function(model) {
        /// <summary>
        ///     Appends a new item to the children datasource, and initializes the datasource, if necessary.
        /// </summary>
        /// <param name="model" type="Object">The data for the new item</param>
    },

    level: function() {
        /// <summary>
        ///     Gets the current nesting level of the Node within the HierarchicalDataSource.var dataSource = new
        ///     HierarchicalDataSource({
        ///     data: [
        ///     { id: 1, text: "Root", items: [
        ///     { id: 2, text: "Child" }
        ///     ] }
        ///     ]
        ///     });dataSource.read();var root = dataSource.get(1);
        ///     equals(root.level(), 0);root.load(); // Load child nodesvar child = dataSource.get(2);
        ///     equals(child.level(), 1);
        /// </summary>
    },

    load: function() {
        /// <summary>
        ///     Loads the child nodes in the child datasource, supplying the `id` of the Node to the request.
        /// </summary>
    },

    loaded: function() {
        /// <summary>
        ///     Gets or sets the loaded flag of the Node. Setting the loaded flag to `false` allows reloading of child items.
        /// </summary>
    },

    parentNode: function() {
        /// <summary>
        ///     Gets the parent node of the Node, if any.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataNode = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.Node widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.Node">The kendo.data.Node instance (if present).</returns>
};

$.fn.kendoDataNode = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.Node widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.ObservableArray = function() {};

kendo.data.ObservableArray.prototype = {
    bind: function(eventName, handler) {
        /// <summary>
        ///     Attaches an event handler for the specified event.
        /// </summary>
        /// <param name="eventName" type="String">The name of the event.</param>
        /// <param name="handler" type="Function">The function which will be invoked when the event is raised.</param>
    },

    join: function(separator) {
        /// <summary>
        ///     Joins all items of an `ObservableArray` into a string. Equivalent of
        ///     [Array.prototype.join](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/join).
        /// </summary>
        /// <param name="separator" type="String">
        ///     Specifies the string to separate each item of the array. If omitted the array
        ///     items are separated with a comma (`,`)
        /// </param>
    },

    parent: function() {
        /// <summary>
        ///     Returns the parent `ObservableObject`. If the current `ObservableArray` is not nested
        ///     returns `undefined`.
        /// </summary>
    },

    pop: function() {
        /// <summary>
        ///     Removes the last item from an array and returns that item. Equivalent of
        ///     [Array.prototype.pop](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/pop).
        /// </summary>
    },

    push: function() {
        /// <summary>
        ///     Appends the given items to the array and returns the new length of the array. Equivalent of
        ///     [Array.prototype.push](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/push).
        ///     The new items are wrapped as `ObservableObject` if they are complex objects.
        /// </summary>
    },

    slice: function(begin, end) {
        /// <summary>
        ///     Returns a one-level deep copy of a portion of an array. Equivalent of
        ///     [Array.prototype.slice](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/slice).
        ///     The result of the `slice` method is **not** an instance of `ObvservableArray`. It is a regular JavaScript Array
        ///     object.
        ///     > **Important:** The `slice` method does not modify the original `ObservableArray`.
        /// </summary>
        /// <param name="begin" type="Number">Zero-based index at which to begin extraction.</param>
        /// <param name="end" type="Number">
        ///     Zero-based index at which to end extraction. If `end` is omitted, `slice` extracts to
        ///     the end of the sequence.
        /// </param>
    },

    splice: function(index, howMany) {
        /// <summary>
        ///     Changes an `ObservableArray`, by adding new items while removing old items. Equivalent of
        ///     [Array.prototype.splice](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/splice)
        /// </summary>
        /// <param name="index" type="Number">
        ///     Index at which to start changing the array. If negative, will begin that many
        ///     elements from the end.
        /// </param>
        /// <param name="howMany" type="Number">
        ///     An integer indicating the number of items to remove. If howMany is 0, no items are
        ///     removed. In this case, you should specify at least one new item.
        /// </param>
        /// <returns
        ///     type="An `Array` containing the removed items. The result of the `splice` method is **not** an instance of `ObvservableArray">
        ///     .
        /// </returns>
    },

    shift: function() {
        /// <summary>
        ///     Removes the first item from an `ObvservableArray` and returns that item. Equivalent of
        ///     [Array.prototype.shift](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/shift).
        /// </summary>
    },

    toJSON: function() {
        /// <summary>
        ///     Returns a JavaScript Array which represents the contents of the `ObservableArray`.
        /// </summary>
    },

    unshift: function() {
        /// <summary>
        ///     Adds one or more items to the beginning of an `ObservableArray` and returns the new length.
        ///     Equivalent of
        ///     [Array.prototype.unshift](http://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Array/unshift).
        /// </summary>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataObservableArray = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.ObservableArray widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.ObservableArray">The kendo.data.ObservableArray instance (if present).</returns>
};

$.fn.kendoDataObservableArray = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.ObservableArray widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.data.ObservableObject = function() {};

kendo.data.ObservableObject.prototype = {
    bind: function(eventName, handler) {
        /// <summary>
        ///     Attaches an event handler for the specified event.
        /// </summary>
        /// <param name="eventName" type="String">The name of the event.</param>
        /// <param name="handler" type="Function">The function which will be invoked when the event is raised.</param>
    },

    get: function(name) {
        /// <summary>
        ///     Gets the value of the specified field.
        /// </summary>
        /// <param name="name" type="String">The name of the field whose value is going to be returned.</param>
        /// <returns type="Object">The value of the specified field.</returns>
    },

    parent: function() {
        /// <summary>
        ///     Returns the parent `ObservableObject`. If the current `ObservableObject` is not
        ///     nested returns `undefined`;
        /// </summary>
    },

    set: function(name, value) {
        /// <summary>
        ///     Sets the value of the specified field.
        /// </summary>
        /// <param name="name" type="String">The name of the field whose value is going to be returned.</param>
        /// <param name="value" type="Number|String|Date|Object">The new value of the field.</param>
    },

    toJSON: function() {
        /// <summary>
        ///     Creates a plain JavaScript object which contains all fields of the `ObservableObject`.
        /// </summary>
        /// <returns type="An `Object` which contains only the fields of the `ObservableObject">.</returns>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDataObservableObject = function() {
    /// <summary>
    ///     Returns a reference to the kendo.data.ObservableObject widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.data.ObservableObject">The kendo.data.ObservableObject instance (if present).</returns>
};

$.fn.kendoDataObservableObject = function(options) {
    /// <summary>
    ///     Instantiates a kendo.data.ObservableObject widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.dataviz.ui.Chart = function() {};

kendo.dataviz.ui.Chart.prototype = {
    destroy: function() {
        /// <summary>
        ///     Prepares the Chart for safe removal from the DOM.Detaches event handlers and removes data entries in order to avoid
        ///     memory leaks.
        /// </summary>
    },

    refresh: function() {
        /// <summary>
        ///     Reloads the data and repaints the chart.
        /// </summary>
    },

    svg: function() {
        /// <summary>
        ///     Returns the SVG representation of the current chart.
        ///     The returned string is a self-contained SVG document
        ///     that can be used as is or converted to other formats
        ///     using tools like [Inkscape](http://inkscape.org/) and
        ///     [ImageMagick](http://www.imagemagick.org/).
        ///     Both programs provide command-line interface
        ///     suitable for backend processing.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDatavizChart = function() {
    /// <summary>
    ///     Returns a reference to the kendo.dataviz.ui.Chart widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.dataviz.ui.Chart">The kendo.dataviz.ui.Chart instance (if present).</returns>
};

$.fn.kendoDatavizChart = function(options) {
    /// <summary>
    ///     Instantiates a kendo.dataviz.ui.Chart widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;axisDefaults — Object undefined
    ///     &#10;Default options for all chart axes.
    ///     &#10;
    ///     &#10;categoryAxis — Object undefined
    ///     &#10;The category axis configuration options.
    ///     &#10;
    ///     &#10;chartArea — Object undefined
    ///     &#10;The chart area configuration options.
    ///     &#10;This is the entire visible area of the chart.
    ///     &#10;
    ///     &#10;dataSource — Object undefined
    ///     &#10;DataSource configuration or instance.
    ///     &#10;
    ///     &#10;legend — Object undefined
    ///     &#10;The chart legend configuration options.
    ///     &#10;
    ///     &#10;plotArea — Object undefined
    ///     &#10;The plot area configuration options. This is the area containing the plotted series.
    ///     &#10;
    ///     &#10;series — Array undefined
    ///     &#10;Array of series definitions.The series type is determined by the value of the type field.
    ///     &#10;If a type value is missing, the type is assumed to be the one specified in seriesDefaults.Each series type has
    ///     a different set of options.
    ///     &#10;
    ///     &#10;seriesColors — Array undefined
    ///     &#10;The default colors for the chart's series. When all colors are used, new colors are pulled from the start
    ///     again.
    ///     &#10;
    ///     &#10;seriesDefaults — Object undefined
    ///     &#10;Default values for each series.
    ///     &#10;
    ///     &#10;theme — String undefined
    ///     &#10;Sets Chart theme. Available themes: default, blueOpal, black.
    ///     &#10;
    ///     &#10;title — Object undefined
    ///     &#10;The chart title configuration options.
    ///     &#10;
    ///     &#10;tooltip — Object undefined
    ///     &#10;The data point tooltip configuration options.
    ///     &#10;
    ///     &#10;transitions — Boolean (default: true)
    ///     &#10;A value indicating if transition animations should be played.
    ///     &#10;
    ///     &#10;valueAxis — Object undefined
    ///     &#10;The value axis configuration options.
    ///     &#10;
    ///     &#10;xAxis — Object undefined
    ///     &#10;Scatter charts X-axis configuration options.
    ///     &#10;Includes **all valueAxis options** in addition to:
    ///     &#10;
    ///     &#10;yAxis — Object undefined
    ///     &#10;The scatter charts Y-axis configuration options.
    ///     &#10;See **xAxis** for list of available options.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.dataviz.ui.LinearGauge = function() {};

kendo.dataviz.ui.LinearGauge.prototype = {
    destroy: function() {
        /// <summary>
        ///     Prepares the Gauge for safe removal from the DOM.Detaches event handlers and removes data entries in order to avoid
        ///     memory leaks.
        /// </summary>
    },

    redraw: function() {
        /// <summary>
        ///     Redraws the gauge.
        /// </summary>
    },

    svg: function() {
        /// <summary>
        ///     Returns the SVG representation of the current gauge.
        ///     The returned string is a self-contained SVG document
        ///     that can be used as is or converted to other formats
        ///     using tools like [Inkscape](http://inkscape.org/) and
        ///     [ImageMagick](http://www.imagemagick.org/).
        ///     Both programs provide command-line interface
        ///     suitable for backend processing.
        /// </summary>
    },

    value: function() {
        /// <summary>
        ///     Change the value of the gauge.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDatavizLinearGauge = function() {
    /// <summary>
    ///     Returns a reference to the kendo.dataviz.ui.LinearGauge widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.dataviz.ui.LinearGauge">The kendo.dataviz.ui.LinearGauge instance (if present).</returns>
};

$.fn.kendoDatavizLinearGauge = function(options) {
    /// <summary>
    ///     Instantiates a kendo.dataviz.ui.LinearGauge widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;gaugeArea — Object undefined
    ///     &#10;The gauge area configuration options.
    ///     &#10;This is the entire visible area of the gauge.
    ///     &#10;
    ///     &#10;pointer — Object undefined
    ///     &#10;The pointer configuration options.
    ///     &#10;
    ///     &#10;scale — Object undefined
    ///     &#10;Configures the scale.
    ///     &#10;
    ///     &#10;transitions — Boolean (default: true)
    ///     &#10;A value indicating if transition animations should be played.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.dataviz.ui.RadialGauge = function() {};

kendo.dataviz.ui.RadialGauge.prototype = {
    destroy: function() {
        /// <summary>
        ///     Prepares the Gauge for safe removal from the DOM.Detaches event handlers and removes data entries in order to avoid
        ///     memory leaks.
        /// </summary>
    },

    redraw: function() {
        /// <summary>
        ///     Redraws the gauge.
        /// </summary>
    },

    svg: function() {
        /// <summary>
        ///     Returns the SVG representation of the current gauge.
        ///     The returned string is a self-contained SVG document
        ///     that can be used as is or converted to other formats
        ///     using tools like [Inkscape](http://inkscape.org/) and
        ///     [ImageMagick](http://www.imagemagick.org/).
        ///     Both programs provide command-line interface
        ///     suitable for backend processing.
        /// </summary>
    },

    value: function() {
        /// <summary>
        ///     Change the value of the gauge.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDatavizRadialGauge = function() {
    /// <summary>
    ///     Returns a reference to the kendo.dataviz.ui.RadialGauge widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.dataviz.ui.RadialGauge">The kendo.dataviz.ui.RadialGauge instance (if present).</returns>
};

$.fn.kendoDatavizRadialGauge = function(options) {
    /// <summary>
    ///     Instantiates a kendo.dataviz.ui.RadialGauge widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;gaugeArea — Object undefined
    ///     &#10;The gauge area configuration options.
    ///     &#10;This is the entire visible area of the gauge.
    ///     &#10;
    ///     &#10;pointer — Object undefined
    ///     &#10;The pointer configuration options.
    ///     &#10;
    ///     &#10;rangeSize — Number undefined
    ///     &#10;The width of the range indicators.
    ///     &#10;
    ///     &#10;scale — Object undefined
    ///     &#10;Configures the scale.
    ///     &#10;
    ///     &#10;transitions — Boolean (default: true)
    ///     &#10;A value indicating if transition animations should be played.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.Application = function() {};

kendo.mobile.Application.prototype = {
    hideLoading: function() {
        /// <summary>
        ///     Hide the loading animation.
        /// </summary>
    },

    navigate: function(url, transition) {
        /// <summary>
        ///     Navigate to local or to remote view.
        /// </summary>
        /// <param name="url" type="String">The id or url of the view.</param>
        /// <param name="transition" type="String">
        ///     The transition to apply when navigating. See [View Transitions
        ///     section](/getting-started/mobile/application/overview#view-transitions) for more information.
        /// </param>
    },

    scroller: function() {
        /// <summary>
        ///     Get a reference to the current view's scroller widget instance.
        /// </summary>
        /// <returns type="Scroller">the scroller widget instance.</returns>
    },

    showLoading: function() {
        /// <summary>
        ///     Show the loading animation.
        /// </summary>
    },

    view: function() {
        /// <summary>
        ///     Get a reference to the current view.
        /// </summary>
        /// <returns type="View">the view instance.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileApplication = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.Application widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.Application">The kendo.mobile.Application instance (if present).</returns>
};

$.fn.kendoMobileApplication = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.Application widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;hideAddressBar — Boolean (default: true)
    ///     &#10;Whether to hide the browser address bar.
    ///     &#10;
    ///     &#10;initial — String undefined
    ///     &#10;The id of the initial mobilie View to display.
    ///     &#10;
    ///     &#10;layout — String undefined
    ///     &#10;The id of the default Application Layout.
    ///     &#10;
    ///     &#10;loading — String (default: Loading...)
    ///     &#10;The text displayed in the loading popup. Setting this value to false will disable the loading popup.
    ///     &#10;
    ///     &#10;platform — String undefined
    ///     &#10;Which platform look to force on the application. Can be one of "ios", "android", "blackberry".
    ///     &#10;
    ///     &#10;transition — String undefined
    ///     &#10;The default View transition.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.ActionSheet = function() {};

kendo.mobile.ui.ActionSheet.prototype = {
    close: function() {
        /// <summary>
        ///     Close the ActionSheet.
        /// </summary>
    },

    open: function(target, context) {
        /// <summary>
        ///     Open the ActionSheet.
        /// </summary>
        /// <param name="target" type="jQuery">(optional) The target of the ActionSheet, available in the callback methods.</param>
        /// <param name="context" type="Object">(optional) The context of the ActionSheet, available in the callback methods.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileActionSheet = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.ActionSheet widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.ActionSheet">The kendo.mobile.ui.ActionSheet instance (if present).</returns>
};

$.fn.kendoMobileActionSheet = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.ActionSheet widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;cancel — String (default: Cancel)
    ///     &#10;The text of the cancel button.
    ///     &#10;
    ///     &#10;popup — Object undefined
    ///     &#10;The popup configuration options (tablet only).
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.BackButton = function() {};

kendo.mobile.ui.BackButton.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileBackButton = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.BackButton widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.BackButton">The kendo.mobile.ui.BackButton instance (if present).</returns>
};

$.fn.kendoMobileBackButton = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.BackButton widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Button = function() {};

kendo.mobile.ui.Button.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileButton = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Button widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Button">The kendo.mobile.ui.Button instance (if present).</returns>
};

$.fn.kendoMobileButton = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Button widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;icon — String undefined
    ///     &#10;The icon of the button. It can be either one of the built-in icons, or a custom one.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.ButtonGroup = function() {};

kendo.mobile.ui.ButtonGroup.prototype = {
    current: function() {
        /// <summary>
        ///     Get the currently selected Button.
        /// </summary>
        /// <returns type="jQuery">the currently selected Button.</returns>
    },

    select: function(li) {
        /// <summary>
        ///     Select a Button.
        /// </summary>
        /// <param name="li" type="jQuery | Number">LI element or index of the Button.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileButtonGroup = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.ButtonGroup widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.ButtonGroup">The kendo.mobile.ui.ButtonGroup instance (if present).</returns>
};

$.fn.kendoMobileButtonGroup = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.ButtonGroup widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;index — Number undefined
    ///     &#10;Defines the initially selected Button.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.DetailButton = function() {};

kendo.mobile.ui.DetailButton.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileDetailButton = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.DetailButton widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.DetailButton">The kendo.mobile.ui.DetailButton instance (if present).</returns>
};

$.fn.kendoMobileDetailButton = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.DetailButton widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Layout = function() {};

kendo.mobile.ui.Layout.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileLayout = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Layout widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Layout">The kendo.mobile.ui.Layout instance (if present).</returns>
};

$.fn.kendoMobileLayout = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Layout widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;id — String (default: null)
    ///     &#10;The id of the layout. Required.
    ///     &#10;
    ///     &#10;platform — String undefined
    ///     &#10;The specific platform this layout targets. By default, layouts are displayed
    ///     &#10;on all platforms.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.ListView = function() {};

kendo.mobile.ui.ListView.prototype = {
    items: function() {
        /// <summary>
        ///     Get the listview DOM element items
        /// </summary>
        /// <returns type="jQuery">The listview DOM element items</returns>
    },

    refresh: function(e) {
        /// <summary>
        ///     Repaints the listview (works only in databound mode).
        /// </summary>
        /// <param name="e" type=""></param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileListView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.ListView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.ListView">The kendo.mobile.ui.ListView instance (if present).</returns>
};

$.fn.kendoMobileListView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.ListView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;appendOnRefresh — Boolean (default: false)
    ///     &#10;Used in combination with pullToRefresh. If set to true, newly loaded data will be appended on top when
    ///     refershing.
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Indicates whether the listview will call read on the DataSource initially.
    ///     &#10;
    ///     &#10;dataSource — kendo.data.DataSource | Object undefined
    ///     &#10;Instance of DataSource or the data that the mobile ListView will be bound to.
    ///     &#10;
    ///     &#10;endlessScroll — Boolean (default: false)
    ///     &#10;If set to true, the listview gets the next page of data when the user scrolls near the bottom of the view.
    ///     &#10;
    ///     &#10;fixedHeaders — Boolean (default: false)
    ///     &#10;If set to true, the group headers will persist their position when the user scrolls through the listview.
    ///     Applicable only when the type is set to group, or when binding to grouped datasource.
    ///     &#10;
    ///     &#10;headerTemplate — String (default: #:value#)
    ///     &#10;The header item template (applicable when the type is set to group).
    ///     &#10;
    ///     &#10;loadMore — Boolean (default: false)
    ///     &#10;If set to true, a button is rendered at the bottom of the listview, which fetch the next page of data when
    ///     tapped.
    ///     &#10;
    ///     &#10;loadMoreText — String (default: "Press to load more")
    ///     &#10;The text of the rendered load-more button (applies only if loadMore is set to true).
    ///     &#10;
    ///     &#10;pullTemplate — String (default: "Pull to refresh")
    ///     &#10;The message template displayed when the user pulls the listView. Applicable only when pullToRefresh is set to
    ///     true.
    ///     &#10;
    ///     &#10;pullToRefresh — Boolean (default: false)
    ///     &#10;If set to true, the listview will reload its data when the user pulls the view over the top limit.
    ///     &#10;
    ///     &#10;refreshTemplate — String (default: "Refreshing")
    ///     &#10;The message template displayed during the refresh. Applicable only when pullToRefresh is set to true.
    ///     &#10;
    ///     &#10;releaseTemplate — String (default: "Release to refresh")
    ///     &#10;The message template indicating that pullToRefresh will occur. Applicable only when pullToRefresh is set to
    ///     true.
    ///     &#10;
    ///     &#10;scrollTreshold — String (default: 30)
    ///     &#10;The distance to the bottom in pixels, after which the listview will start fetching the next page. Applicable
    ///     only when endlessScroll is set to true.
    ///     &#10;
    ///     &#10;style — String undefined
    ///     &#10;The style of the control. Can be either empty string(""), or inset.
    ///     &#10;
    ///     &#10;template — String (default: #:data#)
    ///     &#10;The item template.
    ///     &#10;
    ///     &#10;type — String undefined
    ///     &#10;The type of the control. Can be either `flat` (default) or group. Determined automatically in databound mode.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Loader = function() {};

kendo.mobile.ui.Loader.prototype = {
    hide: function() {
        /// <summary>
        ///     Hide the loading animation.
        /// </summary>
    },

    show: function() {
        /// <summary>
        ///     Show the loading animation.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileLoader = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Loader widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Loader">The kendo.mobile.ui.Loader instance (if present).</returns>
};

$.fn.kendoMobileLoader = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Loader widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.ModalView = function() {};

kendo.mobile.ui.ModalView.prototype = {
    close: function() {
        /// <summary>
        ///     Close the ModalView
        /// </summary>
    },

    open: function(target) {
        /// <summary>
        ///     Open the ModalView
        /// </summary>
        /// <param name="target" type="jQuery">(optional) The target of the ModalView</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileModalView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.ModalView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.ModalView">The kendo.mobile.ui.ModalView instance (if present).</returns>
};

$.fn.kendoMobileModalView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.ModalView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;height — Number undefined
    ///     &#10;The height of the ModalView container in pixels. If not set, the element style is used.
    ///     &#10;
    ///     &#10;modal — Boolean (default: true)
    ///     &#10;When set to false, the ModalView will close when the user taps outside of its element.
    ///     &#10;
    ///     &#10;width — Number undefined
    ///     &#10;The width of the ModalView container in pixels. If not set, the element style is used.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.NavBar = function() {};

kendo.mobile.ui.NavBar.prototype = {
    title: function(value) {
        /// <summary>
        ///     Update the title element text. The title element is specified by setting the `role` data attribute to `view-title`.
        /// </summary>
        /// <param name="value" type="String">The text of title</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileNavBar = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.NavBar widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.NavBar">The kendo.mobile.ui.NavBar instance (if present).</returns>
};

$.fn.kendoMobileNavBar = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.NavBar widget based the DOM elements that match the selector.
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Pane = function() {};

kendo.mobile.ui.Pane.prototype = {
    hideLoading: function() {
        /// <summary>
        ///     Hide the loading animation.
        /// </summary>
    },

    navigate: function(url, transition) {
        /// <summary>
        ///     Navigate the local or remote view.
        /// </summary>
        /// <param name="url" type="String">The id or url of the view.</param>
        /// <param name="transition" type="String">
        ///     The transition to apply when navigating. See View Transitions section for more
        ///     information.
        /// </param>
    },

    showLoading: function() {
        /// <summary>
        ///     Show the loading animation.
        /// </summary>
    },

    view: function() {
        /// <summary>
        ///     Get a reference to the current view.
        /// </summary>
        /// <returns type="View">the view instance.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobilePane = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Pane widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Pane">The kendo.mobile.ui.Pane instance (if present).</returns>
};

$.fn.kendoMobilePane = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Pane widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;initial — String undefined
    ///     &#10;The id of the initial mobilie View to display.
    ///     &#10;
    ///     &#10;layout — String undefined
    ///     &#10;The id of the default Pane Layout.
    ///     &#10;
    ///     &#10;loading — String (default: Loading...)
    ///     &#10;The text displayed in the loading popup. Setting this value to false will disable the loading popup.
    ///     &#10;
    ///     &#10;transition — String undefined
    ///     &#10;The default View transition.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.PopOver = function() {};

kendo.mobile.ui.PopOver.prototype = {
    close: function() {
        /// <summary>
        ///     Close the popover.
        /// </summary>
    },

    openFor: function(target) {
        /// <summary>
        ///     Open the ActionSheet.
        /// </summary>
        /// <param name="target" type="jQuery">The target of the Popover, to which the visual arrow will point to.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobilePopOver = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.PopOver widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.PopOver">The kendo.mobile.ui.PopOver instance (if present).</returns>
};

$.fn.kendoMobilePopOver = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.PopOver widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;pane — Object undefined
    ///     &#10;The pane configuration options.
    ///     &#10;
    ///     &#10;popup — Object undefined
    ///     &#10;The popup configuration options.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.ScrollView = function() {};

kendo.mobile.ui.ScrollView.prototype = {
    content: function(content) {
        /// <summary>
        ///     Update the scrollview HTML content
        /// </summary>
        /// <param name="content" type="String | jQuery">the new scrollView content.</param>
    },

    refresh: function() {
        /// <summary>
        ///     Redraw the mobile ScrollView pager. Called automatically on device orientation change event.
        /// </summary>
    },

    scrollTo: function(page) {
        /// <summary>
        ///     Scroll to the given page. Pages are zero-based indexed.
        /// </summary>
        /// <param name="page" type="Number">The page to scroll to.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileScrollView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.ScrollView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.ScrollView">The kendo.mobile.ui.ScrollView instance (if present).</returns>
};

$.fn.kendoMobileScrollView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.ScrollView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;bounceVelocityThreshold — Number (default: 1.6)
    ///     &#10;The velocity threshold after which a swipe will result in a bounce effect.
    ///     &#10;
    ///     &#10;duration — Number (default: 300)
    ///     &#10;The milliseconds that take the ScrollView to snap to the current page after released.
    ///     &#10;
    ///     &#10;page — Number (default: 0)
    ///     &#10;The initial page to display.
    ///     &#10;
    ///     &#10;velocityThreshold — Number (default: 0.8)
    ///     &#10;The velocity threshold after which a swipe will navigate to the next page (as opposed to snapping back to the
    ///     current page).
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Scroller = function() {};

kendo.mobile.ui.Scroller.prototype = {
    pullHandled: function() {
        /// <summary>
        ///     Indicate that the pull event is handled (i.e. data from the server has been retrieved).
        /// </summary>
    },

    reset: function() {
        /// <summary>
        ///     Scrolls the container to the top.
        /// </summary>
    },

    scrollHeight: function() {
        /// <summary>
        ///     Returns the height in pixels of the scroller content.
        /// </summary>
    },

    scrollTo: function(x, y) {
        /// <summary>
        ///     Scrolls the container to the specified location
        /// </summary>
        /// <param name="x" type="Number">The horizontal offset in pixels to scroll to.</param>
        /// <param name="y" type="Number">The vertical offset in pixels to scroll to.</param>
    },

    scrollWidth: function() {
        /// <summary>
        ///     Returns the width in pixels of the scroller content.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileScroller = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Scroller widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Scroller">The kendo.mobile.ui.Scroller instance (if present).</returns>
};

$.fn.kendoMobileScroller = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Scroller widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;elastic — Boolean (default: true)
    ///     &#10;Weather or not to allow out of bounds dragging and easing.
    ///     &#10;
    ///     &#10;pullOffset — Number (default: 140)
    ///     &#10;The threshold below which a releasing the scroller will trigger the pull event.
    ///     &#10;Has effect only when the pullToRefresh option is set to true.
    ///     &#10;
    ///     &#10;pullTemplate — String (default: Pull to refresh)
    ///     &#10;The message template displayed when the user pulls the scroller.
    ///     &#10;Has effect only when the pullToRefresh option is set to true.
    ///     &#10;
    ///     &#10;pullToRefresh — Boolean (default: false)
    ///     &#10;If set to true, the scroller will display a hint when the user pulls the container beyond its top limit.
    ///     &#10;If a pull beyond the specified pullOffset occurs, a pull event will be triggered.
    ///     &#10;
    ///     &#10;refreshTemplate — String (default: Refreshing)
    ///     &#10;The message template displayed during the refresh.
    ///     &#10;Has effect only when the pullToRefresh option is set to true.
    ///     &#10;
    ///     &#10;releaseTemplate — String (default: Release to refresh)
    ///     &#10;The message template displayed when the user pulls the scroller below the
    ///     &#10;pullOffset, indicating that pullToRefresh will occur.
    ///     &#10;Has effect only when the pullToRefresh option is set to true.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.SplitView = function() {};

kendo.mobile.ui.SplitView.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileSplitView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.SplitView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.SplitView">The kendo.mobile.ui.SplitView instance (if present).</returns>
};

$.fn.kendoMobileSplitView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.SplitView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;style — String (default: horizontal)
    ///     &#10;Defines the SplitView style - horizontal or vertical.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Swipe = function() {};

kendo.mobile.ui.Swipe.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileSwipe = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Swipe widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Swipe">The kendo.mobile.ui.Swipe instance (if present).</returns>
};

$.fn.kendoMobileSwipe = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Swipe widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;maxDuration — Number (default: 1000)
    ///     &#10;The maximum amount of time in milliseconds the swipe event can last. Slower swipes are discarded.
    ///     &#10;
    ///     &#10;maxYDelta — Number (default: 10)
    ///     &#10;The maximum vertical deviation in pixels of the swipe event. Swipe with higher deviation are discarded.
    ///     &#10;
    ///     &#10;minXDelta — Number (default: 30)
    ///     &#10;The minimum horizontal distance in pixels the user should swipe before the event is triggered.
    ///     &#10;
    ///     &#10;surface — jQuery undefined
    ///     &#10;By default, swipe events are tracked only within the element boundries. If a surface is specified, the swipe
    ///     events are extended to the provided surface. This is useful if  the swipe targets are small (or narrow).
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.Switch = function() {};

kendo.mobile.ui.Switch.prototype = {
    check: function(check) {
        /// <summary>
        ///     Get/Set the checked state of the widget.
        /// </summary>
        /// <param name="check" type="Boolean">Whether to turn the widget on or off.</param>
        /// <returns type="Boolean">The checked state of the widget.</returns>
    },

    toggle: function() {
        /// <summary>
        ///     Toggle the checked state of the widget.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileSwitch = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.Switch widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.Switch">The kendo.mobile.ui.Switch instance (if present).</returns>
};

$.fn.kendoMobileSwitch = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.Switch widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;checked — Boolean (default: false)
    ///     &#10;The checked state of the widget.
    ///     &#10;
    ///     &#10;offLabel — String (default: OFF)
    ///     &#10;The OFF label.
    ///     &#10;
    ///     &#10;onLabel — String (default: ON)
    ///     &#10;The ON label.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.TabStrip = function() {};

kendo.mobile.ui.TabStrip.prototype = {
    currentItem: function() {
        /// <summary>
        ///     Get the currently selected tab DOM element.
        /// </summary>
        /// <returns type="jQuery">the currently selected tab DOM element.</returns>
    },

    switchTo: function(url) {
        /// <summary>
        ///     Set the mobile TabStrip active tab to the tab with the specified url.
        /// </summary>
        /// <param name="url" type="String">The url of the tab.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileTabStrip = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.TabStrip widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.TabStrip">The kendo.mobile.ui.TabStrip instance (if present).</returns>
};

$.fn.kendoMobileTabStrip = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.TabStrip widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;selectedIndex — Number (default: 0)
    ///     &#10;The index of the initially selected tab.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.mobile.ui.View = function() {};

kendo.mobile.ui.View.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMobileView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.mobile.ui.View widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.mobile.ui.View">The kendo.mobile.ui.View instance (if present).</returns>
};

$.fn.kendoMobileView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.mobile.ui.View widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;model — String | ObservableObject (default: null)
    ///     &#10;The MVVM model to bind to. If a string is passed, The view
    ///     &#10;will try to resolve a reference to the view model variable in the global scope.
    ///     &#10;
    ///     &#10;stretch — Boolean (default: false)
    ///     &#10;If set to true, the view will stretch its child contents to occupy the entire view, while disabling kinetic
    ///     scrolling.
    ///     &#10;Useful if the view contains an image or a map.
    ///     &#10;
    ///     &#10;title — String undefined
    ///     &#10;The text to display in the navbar title (if present) and the browser title.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui = {};

kendo.ui.AutoComplete = function() {};

kendo.ui.AutoComplete.prototype = {
    close: function() {
        /// <summary>
        ///     Closes the drop-down list.
        /// </summary>
    },

    dataItem: function(index) {
        /// <summary>
        ///     Returns the raw data record at the specified index
        /// </summary>
        /// <param name="index" type="Number">The zero-based index of the data record</param>
        /// <returns type="Object">The raw data record. Returns <i>undefined</i> if no data.</returns>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enable/Disable the autocomplete widget.
        /// </summary>
        /// <param name="enable" type="Boolean">The argument, which defines whether to enable/disable the autocomplete.</param>
    },

    refresh: function() {
        /// <summary>
        ///     Re-render the items in drop-down list.
        /// </summary>
    },

    search: function(word) {
        /// <summary>
        ///     Filters dataSource using the provided parameter and rebinds drop-down list.
        /// </summary>
        /// <param name="word" type="string">The filter value.</param>
    },

    select: function(li) {
        /// <summary>
        ///     Selects drop-down list item and sets the text of the autocomplete.
        /// </summary>
        /// <param name="li" type="jQuery Object">The LI element.</param>
    },

    suggest: function(value) {
        /// <summary>
        ///     Forces a suggestion onto the text of the AutoComplete.
        /// </summary>
        /// <param name="value" type="string">Characters to force a suggestion.</param>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the autocomplete.
        /// </summary>
        /// <param name="value" type="String">The value to set.</param>
        /// <returns type="String">The value of the autocomplete.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoAutoComplete = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.AutoComplete widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.AutoComplete">The kendo.ui.AutoComplete instance (if present).</returns>
};

$.fn.kendoAutoComplete = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.AutoComplete widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;Animations to be used for opening/closing the popup. Setting to false will turn of the animation.
    ///     &#10;
    ///     &#10;dataSource — Object | kendo.data.DataSource undefined
    ///     &#10;The set of data that the AutoComplete will be bound to.
    ///     &#10;Either a local JavaScript object, or an instance of the Kendo UI DataSource.
    ///     &#10;
    ///     &#10;dataTextField — String (default: null)
    ///     &#10;Sets the field of the data item that provides the text content of the list items.
    ///     &#10;
    ///     &#10;delay — Number (default: 200)
    ///     &#10;Specifies the delay in ms after which the AutoComplete will start filtering the dataSource.
    ///     &#10;
    ///     &#10;enable — Boolean (default: true)
    ///     &#10;Controls whether the AutoComplete should be initially enabled.
    ///     &#10;
    ///     &#10;filter — String (default: "startswith")
    ///     &#10;Defines the type of filtration. This value is handled by the remote data source.
    ///     &#10;
    ///     &#10;height — Number (default: 200)
    ///     &#10;Sets the height of the drop-down list in pixels.
    ///     &#10;
    ///     &#10;highlightFirst — Boolean (default: true)
    ///     &#10;Controls whether the first item will be automatically highlighted.
    ///     &#10;
    ///     &#10;ignoreCase — String (default: true)
    ///     &#10;Defines whether the filtration should be case sensitive.
    ///     &#10;
    ///     &#10;minLength — Number (default: 1)
    ///     &#10;Specifies the minimum number of characters that should be typed before the AutoComplete queries
    ///     &#10;the dataSource.
    ///     &#10;
    ///     &#10;placeholder — String (default: "")
    ///     &#10;A string that appears in the textbox when it has no value.
    ///     &#10;
    ///     &#10;separator — String (default: "")
    ///     &#10;Sets the separator for completion. Empty by default, allowing for only one completion.
    ///     &#10;
    ///     &#10;suggest — Boolean (default: false)
    ///     &#10;Controls whether the AutoComplete should automatically auto-type the rest of text.
    ///     &#10;
    ///     &#10;template — String undefined
    ///     &#10;Template to be used for rendering the items in the list.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Calendar = function() {};

kendo.ui.Calendar.prototype = {
    max: function(value) {
        /// <summary>
        ///     Gets/Sets the max value of the calendar.
        /// </summary>
        /// <param name="value" type="Date | String">The max date to set.</param>
        /// <returns type="Date">The max value of the calendar.</returns>
    },

    min: function(value) {
        /// <summary>
        ///     Gets/Sets the min value of the calendar.
        /// </summary>
        /// <param name="value" type="Date|String">The min date to set.</param>
        /// <returns type="Date">The min value of the calendar.</returns>
    },

    navigate: function(value, view) {
        /// <summary>
        ///     Navigates to view
        /// </summary>
        /// <param name="value" type="Date">Desired date</param>
        /// <param name="view" type="String">Desired view</param>
    },

    navigateDown: function(value) {
        /// <summary>
        ///     Navigates to the lower view
        /// </summary>
        /// <param name="value" type="Date">Desired date</param>
    },

    navigateToFuture: function() {
        /// <summary>
        ///     Navigates to the future
        /// </summary>
    },

    navigateToPast: function() {
        /// <summary>
        ///     Navigates to the past
        /// </summary>
    },

    navigateUp: function() {
        /// <summary>
        ///     Navigates to the upper view
        /// </summary>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the calendar.
        /// </summary>
        /// <param name="value" type="Date|String">The date to set.</param>
        /// <returns type="Date">The value of the calendar.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoCalendar = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Calendar widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Calendar">The kendo.ui.Calendar instance (if present).</returns>
};

$.fn.kendoCalendar = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Calendar widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;culture — String (default: en-US)
    ///     &#10;Specifies the culture info used by the widget.
    ///     &#10;
    ///     &#10;dates — Array undefined
    ///     &#10;Specifies a list of dates, which will be passed to the month template.
    ///     &#10;
    ///     &#10;depth — String undefined
    ///     &#10;Specifies the navigation depth.
    ///     &#10;
    ///     &#10;footer — String undefined
    ///     &#10;Specifies the content of the footer. If false, the footer will not be rendered.
    ///     &#10;
    ///     &#10;footer — String undefined
    ///     &#10;Template to be used for rendering the footer. If false, the footer will not be rendered.
    ///     &#10;
    ///     &#10;format — String (default: MM/dd/yyyy)
    ///     &#10;Specifies the format, which is used to parse value set with value() method.
    ///     &#10;
    ///     &#10;max — Date (default: Date(2099, 11, 31))
    ///     &#10;Specifies the maximum date, which the calendar can show.
    ///     &#10;
    ///     &#10;min — Date (default: Date(1900, 0, 1))
    ///     &#10;Specifies the minimum date, which the calendar can show.
    ///     &#10;
    ///     &#10;month — Object undefined
    ///     &#10;Templates for the cells rendered in the "month" view.
    ///     &#10;
    ///     &#10;start — String (default: month)
    ///     &#10;Specifies the start view.
    ///     &#10;
    ///     &#10;value — Date (default: null)
    ///     &#10;Specifies the selected date.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.ComboBox = function() {};

kendo.ui.ComboBox.prototype = {
    close: function() {
        /// <summary>
        ///     Closes the drop-down list.
        /// </summary>
    },

    dataItem: function(index) {
        /// <summary>
        ///     Returns the raw data record at the specified index. If the index is not specified, the selected index will be used.
        /// </summary>
        /// <param name="index" type="Number">The zero-based index of the data record</param>
        /// <returns type="Object">The raw data record. Returns <i>undefined</i> if no data.</returns>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enables/disables the combobox widget
        /// </summary>
        /// <param name="enable" type="Boolean">Desired state</param>
    },

    open: function() {
        /// <summary>
        ///     Opens the drop-down list.
        /// </summary>
    },

    refresh: function() {
        /// <summary>
        ///     Re-render the items of the drop-down list.
        /// </summary>
    },

    search: function(word) {
        /// <summary>
        ///     Filters dataSource using the provided parameter and rebinds drop-down list.
        /// </summary>
        /// <param name="word" type="string">The filter value.</param>
    },

    select: function(li) {
        /// <summary>
        ///     Selects drop-down list item and sets the value and the text of the combobox.
        /// </summary>
        /// <param name="li" type="jQuery | Number | Function">
        ///     LI element or index of the item or predicate function, which defines
        ///     the item that should be selected.
        /// </param>
        /// <returns type="Number">The index of the selected LI element.</returns>
    },

    suggest: function(value) {
        /// <summary>
        ///     Forces a suggestion onto the text of the ComboBox.
        /// </summary>
        /// <param name="value" type="string">Characters to force a suggestion.</param>
    },

    text: function(text) {
        /// <summary>
        ///     Gets/Sets the text of the ComboBox.
        /// </summary>
        /// <param name="text" type="String">The text to set.</param>
        /// <returns type="String">The text of the combobox.</returns>
    },

    toggle: function(toggle) {
        /// <summary>
        ///     Toggles the drop-down list between opened and closed state.
        /// </summary>
        /// <param name="toggle" type="Boolean">Defines the whether to open/close the drop-down list.</param>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the combobox. If the value is undefined, text of the data item will be used.
        /// </summary>
        /// <param name="value" type="String">The value to set.</param>
        /// <returns type="String">The value of the combobox.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoComboBox = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.ComboBox widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.ComboBox">The kendo.ui.ComboBox instance (if present).</returns>
};

$.fn.kendoComboBox = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.ComboBox widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;Animations to be used for opening/closing the popup. Setting to false will turn off the animation.
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Controls whether to bind the widget to the DataSource on initialization.
    ///     &#10;
    ///     &#10;cascadeFrom — String undefined
    ///     &#10;Use it to set the Id of the parent DropDownList.
    ///     &#10;
    ///     &#10;dataSource — Object | kendo.data.DataSource undefined
    ///     &#10;A local JavaScript object or instance of DataSource or the data that the ComboBox will be bound to.
    ///     &#10;
    ///     &#10;dataTextField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the text content of the list items.
    ///     &#10;
    ///     &#10;dataValueField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the value content of the list items.
    ///     &#10;
    ///     &#10;delay — Number (default: 200)
    ///     &#10;Specifies the delay in ms after which the ComboBox will start filtering dataSource.
    ///     &#10;
    ///     &#10;enable — Boolean (default: true)
    ///     &#10;Controls whether the ComboBox should be initially enabled.
    ///     &#10;
    ///     &#10;filter — String (default: "none")
    ///     &#10;Defines the type of filtration. If "none" the ComboBox will not filter the items.
    ///     &#10;
    ///     &#10;height — Number (default: 200)
    ///     &#10;Define the height of the drop-down list in pixels.
    ///     &#10;
    ///     &#10;highlightFirst — Boolean (default: true)
    ///     &#10;Controls whether the first item will be automatically highlighted.
    ///     &#10;
    ///     &#10;ignoreCase — String (default: true)
    ///     &#10;Defines whether the filtration should be case sensitive.
    ///     &#10;
    ///     &#10;index — Number (default: -1)
    ///     &#10;Defines the initial selected item.
    ///     &#10;
    ///     &#10;minLength — Number (default: 1)
    ///     &#10;Specifies the minimum characters that should be typed before the ComboBox activates
    ///     &#10;
    ///     &#10;placeholder — String (default: "")
    ///     &#10;A string that appears in the textbox when the combobox has no value.
    ///     &#10;
    ///     &#10;suggest — Boolean (default: false)
    ///     &#10;Controls whether the ComboBox should automatically auto-type the rest of text.
    ///     &#10;
    ///     &#10;template — string undefined
    ///     &#10;Template to be used for rendering the items in the list.
    ///     &#10;
    ///     &#10;text — String (default: "")
    ///     &#10;Define the text of the widget, when the autoBind is set to false.
    ///     &#10;
    ///     &#10;value — String (default: "")
    ///     &#10;Define the value of the widget
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.DatePicker = function() {};

kendo.ui.DatePicker.prototype = {
    close: function() {
        /// <summary>
        ///     Closes the calendar.
        /// </summary>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enable/Disable the datePicker widget.
        /// </summary>
        /// <param name="enable" type="Boolean">The argument, which defines whether to enable/disable the datePicker.</param>
    },

    max: function(value) {
        /// <summary>
        ///     Gets/Sets the max value of the datePicker.
        /// </summary>
        /// <param name="value" type="Date | String">The max date to set.</param>
        /// <returns type="Date">The max value of the datePicker.</returns>
    },

    min: function(value) {
        /// <summary>
        ///     Gets/Sets the min value of the datePicker.
        /// </summary>
        /// <param name="value" type="Date | String">The min date to set.</param>
        /// <returns type="Date">The min value of the datePicker.</returns>
    },

    open: function() {
        /// <summary>
        ///     Opens the calendar.
        /// </summary>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the datePicker.
        /// </summary>
        /// <param name="value" type="Date | String">The value to set.</param>
        /// <returns type="Date">The value of the datePicker.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDatePicker = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.DatePicker widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.DatePicker">The kendo.ui.DatePicker instance (if present).</returns>
};

$.fn.kendoDatePicker = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.DatePicker widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;The animation(s) used for opening and/or closing the pop-up. Setting this value to **false**
    ///     &#10;will disable the animation(s).
    ///     &#10;
    ///     &#10;culture — String (default: en-US)
    ///     &#10;Specifies the culture info used by the widget.
    ///     &#10;
    ///     &#10;depth — String undefined
    ///     &#10;Specifies the navigation depth. The following
    ///     &#10;settings are available for the **depth** value:
    ///     &#10;
    ///     &#10;footer — String undefined
    ///     &#10;Template to be used for rendering the footer of the calendar.
    ///     &#10;
    ///     &#10;format — String (default: MM/dd/yyyy)
    ///     &#10;Specifies the format, which is used to format the value of the DatePicker displayed in the input. The format
    ///     also will be used to parse the input.
    ///     &#10;
    ///     &#10;max — Date (default: Date(2099, 11, 31))
    ///     &#10;Specifies the maximum date, which the calendar can show.
    ///     &#10;
    ///     &#10;min — Date (default: Date(1900, 0, 1))
    ///     &#10;Specifies the minimum date that the calendar can show.
    ///     &#10;
    ///     &#10;month — Object undefined
    ///     &#10;Templates for the cells rendered in the calendar "month" view.
    ///     &#10;
    ///     &#10;parseFormats — Array undefined
    ///     &#10;Specifies the formats, which are used to parse the value set with value() method or by direct input. If not
    ///     set the value of the format will be used. Note that value of the format option is always used.
    ///     &#10;
    ///     &#10;start — String (default: month)
    ///     &#10;Specifies the start view.
    ///     &#10;The following settings are available for the **start** value:
    ///     &#10;
    ///     &#10;value — Date (default: null)
    ///     &#10;Specifies the selected date.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.DateTimePicker = function() {};

kendo.ui.DateTimePicker.prototype = {
    close: function(view) {
        /// <summary>
        ///     Closes the calendar or the time drop-down list.
        /// </summary>
        /// <param name="view" type="String">
        ///     The view of the DateTimePicker, expressed as a string. Available views are "time" and
        ///     "date".
        /// </param>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enables or disables a DateTimePicker.
        /// </summary>
        /// <param name="enable" type="Boolean">Enables (**true** or undefined) or disables (**false**) a DateTimePicker.</param>
    },

    max: function(value) {
        /// <summary>
        ///     Gets or sets the maximum value of the DateTimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The maximum time value to set for a DateTimePicker, expressed as a Date object
        ///     or as a string.
        /// </param>
        /// <returns type="Date">The maximum time value of a DateTimePicker.</returns>
    },

    min: function(value) {
        /// <summary>
        ///     Gets or sets the minimum value of the DateTimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The minimum time value to set for a DateTimePicker, expressed as a Date object
        ///     or as a string.
        /// </param>
        /// <returns type="Date">The minimum time value of a DateTimePicker.</returns>
    },

    open: function(view) {
        /// <summary>
        ///     Opens the calendar or the time drop-down list.
        /// </summary>
        /// <param name="view" type="String">
        ///     The view of the DateTimePicker, expressed as a string. Available views are "time" and
        ///     "date".
        /// </param>
    },

    toggle: function(view) {
        /// <summary>
        ///     Toggles the calendar or the time drop-down list.
        /// </summary>
        /// <param name="view" type="String">
        ///     The view of the DateTimePicker, expressed as a string. Available views are "time" and
        ///     "date".
        /// </param>
    },

    value: function(value) {
        /// <summary>
        ///     Gets or sets the value of the DateTimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The time value to set for a DateTimePicker, expressed as a Date object or as a
        ///     string.
        /// </param>
        /// <returns type="Date">The time value of a DateTimePicker.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDateTimePicker = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.DateTimePicker widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.DateTimePicker">The kendo.ui.DateTimePicker instance (if present).</returns>
};

$.fn.kendoDateTimePicker = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.DateTimePicker widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;The animation(s) used for opening and/or closing the pop-ups. Setting this value to **false**
    ///     &#10;will disable the animation(s).
    ///     &#10;
    ///     &#10;culture — String (default: en-US)
    ///     &#10;Specifies the culture info used by the widget.
    ///     &#10;
    ///     &#10;dates — Array undefined
    ///     &#10;Specifies a list of dates, which are shown in the time drop-down list. If not set, the DateTimePicker will
    ///     auto-generate the available times.
    ///     &#10;
    ///     &#10;depth — String undefined
    ///     &#10;Specifies the navigation depth of the calendar. The following
    ///     &#10;settings are available for the **depth** value:
    ///     &#10;
    ///     &#10;footer — String undefined
    ///     &#10;Template to be used for rendering the footer of the calendar.
    ///     &#10;
    ///     &#10;format — String (default: MM/dd/yyyy h:mm tt)
    ///     &#10;Specifies the format, which is used to format the value of the DateTimePicker displayed in the input. The
    ///     format also will be used to parse the input.
    ///     &#10;
    ///     &#10;interval — Number (default: 30)
    ///     &#10;Specifies the interval, between values in the popup list, in minutes.
    ///     &#10;
    ///     &#10;max — Date (default: Date(2099, 11, 31))
    ///     &#10;Specifies the maximum date, which the calendar can show.
    ///     &#10;
    ///     &#10;min — Date (default: Date(1900, 0, 1))
    ///     &#10;Specifies the minimum date that the calendar can show.
    ///     &#10;
    ///     &#10;month — Object undefined
    ///     &#10;Templates for the cells rendered in the calendar "month" view.
    ///     &#10;
    ///     &#10;parseFormats — Array undefined
    ///     &#10;Specifies the formats, which are used to parse the value set with value() method or by direct input. If not
    ///     set the value of the options.format and options.timeFormat will be used. Note that value of the format option is
    ///     always used.
    ///     &#10;
    ///     &#10;start — String (default: month)
    ///     &#10;Specifies the start view of the calendar.
    ///     &#10;The following settings are available for the **start** value:
    ///     &#10;
    ///     &#10;timeFormat — String (default: h:mm tt)
    ///     &#10;Specifies the format, which is used to format the values in the time drop-down list.
    ///     &#10;
    ///     &#10;value — Date (default: null)
    ///     &#10;Specifies the selected value.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Draggable = function() {};

kendo.ui.Draggable.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDraggable = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Draggable widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Draggable">The kendo.ui.Draggable instance (if present).</returns>
};

$.fn.kendoDraggable = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Draggable widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;axis — String (default: null)
    ///     &#10;Constrains the hint movement to either the horizontal (x) or vertical (y) axis. Can be set to either "x" or
    ///     "y".
    ///     &#10;
    ///     &#10;container — jQuery undefined
    ///     &#10;If set, the hint movement is constrained to the container boundaries.
    ///     &#10;
    ///     &#10;cursorOffset — Object (default: null)
    ///     &#10;If set, specifies the offset of the hint relative to the mouse cursor/finger.
    ///     &#10;By default, the hint is initially positioned on top of the draggable source offset. The option accepts an
    ///     object with two keys: `top` and `left`.
    ///     &#10;
    ///     &#10;distance — Number (default: 5)
    ///     &#10;The required distance that the mouse should travel in order to initiate a drag.
    ///     &#10;
    ///     &#10;filter — Selector undefined
    ///     &#10;Selects child elements that are draggable if a widget is attached to a container.
    ///     &#10;
    ///     &#10;group — String (default: "default")
    ///     &#10;Used to group sets of draggable and drop targets. A draggable with the same group value as a drop target will
    ///     be accepted by the drop target.
    ///     &#10;
    ///     &#10;hint — Function | jQuery undefined
    ///     &#10;Provides a way for customization of the drag indicator. If a function is supplied, it receives one argument -
    ///     the draggable element's jQuery object.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.DropDownList = function() {};

kendo.ui.DropDownList.prototype = {
    close: function() {
        /// <summary>
        ///     Closes the drop-down list.
        /// </summary>
    },

    dataItem: function(index) {
        /// <summary>
        ///     Returns the raw data record at the specified index. If the index is not specified, the selected index will be used.
        /// </summary>
        /// <param name="index" type="Number">The zero-based index of the data record</param>
        /// <returns type="Object">The raw data record. Returns <i>undefined</i> if no data.</returns>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enables/disables the dropdownlist widget
        /// </summary>
        /// <param name="enable" type="Boolean">Desired state</param>
    },

    open: function() {
        /// <summary>
        ///     Opens the drop-down list.
        /// </summary>
    },

    refresh: function() {
        /// <summary>
        ///     Re-render the items in drop-down list.
        /// </summary>
    },

    search: function(word) {
        /// <summary>
        ///     Selects item, which starts with the provided parameter.
        /// </summary>
        /// <param name="word" type="string">The search value.</param>
    },

    select: function(li) {
        /// <summary>
        ///     Selects drop-down list item and sets the value and the text of the dropdownlist.
        /// </summary>
        /// <param name="li" type="jQuery | Number | Function">
        ///     LI element or index of the item or predicate function, which defines
        ///     the item that should be selected.
        /// </param>
        /// <returns type="Number">The index of the selected LI element.</returns>
    },

    text: function(text) {
        /// <summary>
        ///     Gets/Sets the text of the dropdownlist.
        /// </summary>
        /// <param name="text" type="String">The text to set.</param>
        /// <returns type="String">The text of the dropdownlist.</returns>
    },

    toggle: function(toggle) {
        /// <summary>
        ///     Toggles the drop-down list between opened and closed state.
        /// </summary>
        /// <param name="toggle" type="Boolean">Defines the whether to open/close the drop-down list.</param>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the dropdownlist. The value will not be set if there is no item with such value. If value is
        ///     undefined, text of the data item is used.
        /// </summary>
        /// <param name="value" type="String">The value to set.</param>
        /// <returns type="String">The value of the dropdownlist.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDropDownList = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.DropDownList widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.DropDownList">The kendo.ui.DropDownList instance (if present).</returns>
};

$.fn.kendoDropDownList = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.DropDownList widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;Animations to be used for opening/closing the popup. Setting to false will turn of the animation.
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Controls whether to bind the widget on initialization.
    ///     &#10;
    ///     &#10;cascadeFrom — String undefined
    ///     &#10;Use it to set the Id of the parent DropDownList.
    ///     &#10;
    ///     &#10;dataSource — kendo.data.DataSource | Object undefined
    ///     &#10;Instance of DataSource or the data that the DropDownList will be bound to.
    ///     &#10;
    ///     &#10;dataTextField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the text content of the list items.
    ///     &#10;
    ///     &#10;dataValueField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the value content of the list items.
    ///     &#10;
    ///     &#10;delay — Number (default: 500)
    ///     &#10;Specifies the delay in ms before the search text typed by the end user is cleared.
    ///     &#10;
    ///     &#10;enable — Boolean (default: true)
    ///     &#10;Controls whether the DropDownList should be initially enabled.
    ///     &#10;
    ///     &#10;height — Number (default: 200)
    ///     &#10;Define the height of the drop-down list in pixels.
    ///     &#10;
    ///     &#10;ignoreCase — String (default: true)
    ///     &#10;Controls whether the search should be case sensitive.
    ///     &#10;
    ///     &#10;index — Number (default: 0)
    ///     &#10;Defines the initial selected item.
    ///     &#10;
    ///     &#10;optionLabel — String | Object (default: "")
    ///     &#10;Define the text of the default empty item. If the value is an object, then the widget will use it directly.
    ///     &#10;
    ///     &#10;template — String undefined
    ///     &#10;Template to be used for rendering the items in the list.
    ///     &#10;
    ///     &#10;text — String (default: "")
    ///     &#10;Define the text of the widget, when the autoBind is set to false.
    ///     &#10;
    ///     &#10;value — String (default: "")
    ///     &#10;Define the value of the widget
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.DropTarget = function() {};

kendo.ui.DropTarget.prototype = {
    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoDropTarget = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.DropTarget widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.DropTarget">The kendo.ui.DropTarget instance (if present).</returns>
};

$.fn.kendoDropTarget = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.DropTarget widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;group — String (default: "default")
    ///     &#10;Used to group sets of draggable and drop targets. A draggable with the same group value as a drop target will
    ///     be accepted by the drop target.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Editor = function() {};

kendo.ui.Editor.prototype = {
    createRange: function(document) {
        /// <summary>
        ///     Creates a W3C-compatible **Range** object.
        /// </summary>
        /// <param name="document" type="Document">
        ///     The document that the range is associated with. If ommited, the document of the
        ///     editor editing area will be used.
        /// </param>
        /// <returns type="Range">The created **Range** object.</returns>
    },

    encodedValue: function() {
        /// <summary>
        ///     Gets the HTML encoded value of the editor.
        /// </summary>
    },

    exec: function(name, params) {
        /// <summary>
        ///     Executes an editor command on the currently selected text.
        /// </summary>
        /// <param name="name" type="String">The name of the command to be executed.</param>
        /// <param name="params" type="String">The parameters for the executed command.</param>
    },

    focus: function() {
        /// <summary>
        ///     Focuses the editable area.
        /// </summary>
    },

    getRange: function() {
        /// <summary>
        ///     Gets a **Range** object form the editable area.
        /// </summary>
        /// <returns type="Range">A W3C-compatible **Range** object that represents the currently selected text in the editor area.</returns>
    },

    getSelection: function() {
        /// <summary>
        ///     Gets a W3C-compatible **Selection** object form the editable area.
        /// </summary>
    },

    paste: function(html) {
        /// <summary>
        ///     Pastes HTML into the editable area.
        /// </summary>
        /// <param name="html" type="String">The HTML to be pasted.</param>
    },

    selectedHtml: function() {
        /// <summary>
        ///     Serializes the currently selected text to a XHTML string.
        /// </summary>
        /// <returns type="String">The selectied text as valid XHTML.</returns>
    },

    selectRange: function(range) {
        /// <summary>
        ///     Focuses the editable area and selects the range described by the range parameter.
        /// </summary>
        /// <param name="range" type="Range">The **Range** object that describes the new selection.</param>
    },

    update: function() {
        /// <summary>
        ///     Serializes the current state of the editable area to the `
        ///     <textarea>
        ///         ` element.
        ///         This method should be called after modifying the editor content through the DOM.
        /// </summary>
    },

    value: function(value) {
        /// <summary>
        ///     Gets or sets the Editor value.
        /// </summary>
        /// <param name="value" type="String">The value to set.</param>
        /// <returns type="String">The value of the Editor as HTML string.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoEditor = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Editor widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Editor">The kendo.ui.Editor instance (if present).</returns>
};

$.fn.kendoEditor = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Editor widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;encoded — Boolean undefined
    ///     &#10;Indicates whether the Editor should submit encoded HTML tags.
    ///     &#10;
    ///     &#10;stylesheets — Array undefined
    ///     &#10;Allows custom stylesheets to be included within the editing area.
    ///     &#10;
    ///     &#10;tools — Array undefined
    ///     &#10;A collection of tools that should render a button, combobox, etc, to interact with the Editor. Custom tools
    ///     are defined
    ///     &#10;as a collection of required properties, while the insertHtml  tool requires a collection of text-value pairs
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Grid = function() {};

kendo.ui.Grid.prototype = {
    addRow: function() {
        /// <summary>
        ///     Adds a new empty table row in edit mode. The addRow method triggers edit event.
        /// </summary>
    },

    cancelChanges: function() {
        /// <summary>
        ///     Cancels any pending changes during. Deleted rows are restored. Inserted rows are removed. Updated rows are restored
        ///     to their original values.
        /// </summary>
    },

    cancelRow: function() {
        /// <summary>
        ///     Switch the current edited row into display mode and revert changes made to the data
        /// </summary>
    },

    cellIndex: function(cell) {
        /// <summary>
        ///     Returns the index of the cell in the grid item skipping group and hierarchy cells.
        /// </summary>
        /// <param name="cell" type="Selector | DOM Element">Target cell.</param>
    },

    clearSelection: function() {
        /// <summary>
        ///     Clears currently selected items.
        /// </summary>
    },

    closeCell: function() {
        /// <summary>
        ///     Closes current edited cell.
        /// </summary>
    },

    collapseGroup: function(group) {
        /// <summary>
        ///     Collapses specified group.
        /// </summary>
        /// <param name="group" type="Selector | DOM Element">Target group item to collapse.</param>
    },

    collapseRow: function(row) {
        /// <summary>
        ///     Collapses specified master row.
        /// </summary>
        /// <param name="row" type="Selector | DOM Element">Target master row to collapse.</param>
    },

    dataItem: function(tr) {
        /// <summary>
        ///     Returns the data item to which a given table row (tr DOM element) is bound.
        /// </summary>
        /// <param name="tr" type="Selector | DOM Element">Target row.</param>
    },

    editCell: function(cell) {
        /// <summary>
        ///     Puts the specified table cell in edit mode. It requires a jQuery object representing the cell. The editCell method
        ///     triggers edit event.
        /// </summary>
        /// <param name="cell" type="Selector">Cell to be edited.</param>
    },

    editRow: function(row) {
        /// <summary>
        ///     Switches the specified row from the grid into edit mode. The editRow method triggers edit event.
        /// </summary>
        /// <param name="row" type="Selector | DOM Element">Row to be edited.</param>
    },

    expandGroup: function(group) {
        /// <summary>
        ///     Expands specified group.
        /// </summary>
        /// <param name="group" type="Selector | DOM Element">Target group item to expand.</param>
    },

    expandRow: function(row) {
        /// <summary>
        ///     Expands specified master row.
        /// </summary>
        /// <param name="row" type="Selector | DOM Element">Target master row to expand.</param>
    },

    hideColumn: function(column) {
        /// <summary>
        ///     Hides the specified column.
        /// </summary>
        /// <param name="column" type="Number | String">The index or the bound field of the column to hide.</param>
    },

    refresh: function() {
        /// <summary>
        ///     Redraws the grid using the current data of the DataSource.
        /// </summary>
    },

    removeRow: function(row) {
        /// <summary>
        ///     Removes the specified row from the grid. The removeRow method triggers remove event.
        ///     (Note: In inline or popup edit modes the changes will be automatically synced)
        /// </summary>
        /// <param name="row" type="Selector | DOM Element">Row to be removed.</param>
    },

    saveChanges: function() {
        /// <summary>
        ///     Calls DataSource sync to submit any pending changes if state is valid. The saveChanges method triggers saveChanges
        ///     event.
        /// </summary>
    },

    saveRow: function() {
        /// <summary>
        ///     Switch the current edited row into dislay mode and save changes made to the data
        ///     (Note: the changes will be automatically synced)
        /// </summary>
    },

    select: function(items) {
        /// <summary>
        ///     Selects the specified Grid rows/cells. If called without arguments - returns the selected rows/cells.
        /// </summary>
        /// <param name="items" type="Selector | Array">Items to select.</param>
    },

    showColumn: function(column) {
        /// <summary>
        ///     Shows the specified column.
        /// </summary>
        /// <param name="column" type="Number | String">The index or the bound field of the column to show.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoGrid = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Grid widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Grid">The kendo.ui.Grid instance (if present).</returns>
};

$.fn.kendoGrid = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Grid widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Indicates whether the grid will call read on the DataSource initially.
    ///     &#10;
    ///     &#10;columns — Array undefined
    ///     &#10;A collection of column objects or collection of strings that represents the name of the fields.
    ///     &#10;
    ///     &#10;dataSource — kendo.data.DataSource | Object undefined
    ///     &#10;Instance of DataSource or Object with DataSource configuration.
    ///     &#10;
    ///     &#10;detailTemplate — Function undefined
    ///     &#10;Template to be used for rendering the detail rows in the grid.
    ///     &#10;See the [**Detail Template**](http://demos.kendoui.com/web/grid/detailtemplate.html) example.
    ///     &#10;
    ///     &#10;editable — Object undefined
    ///     &#10;Indicates whether editing is enabled/disabled.
    ///     &#10;
    ///     &#10;groupable — Boolean (default: false)
    ///     &#10;Indicates whether grouping is enabled/disabled.
    ///     &#10;
    ///     &#10;navigatable — Boolean (default: false)
    ///     &#10;Indicates whether keyboard navigation is enabled/disabled.
    ///     &#10;
    ///     &#10;pageable — Boolean | Object (default: false)
    ///     &#10;Indicates whether paging is enabled/disabled.
    ///     &#10;
    ///     &#10;rowTemplate — Function undefined
    ///     &#10;Template to be used for rendering the rows in the grid.
    ///     &#10;
    ///     &#10;scrollable — Boolean | Object (default: true)
    ///     &#10;Enable/disable grid scrolling. Possible values:
    ///     &#10;
    ///     &#10;selectable — String (default: undefined)
    ///     &#10;Indicates whether selection is enabled/disabled. Possible values:
    ///     &#10;
    ///     &#10;sortable — Object undefined
    ///     &#10;Defines whether grid columns are sortable.
    ///     &#10;
    ///     &#10;toolbar — Array undefined
    ///     &#10;This is a list of commands for which the corresponding buttons will be rendered.
    ///     &#10;The supported built-in commands are: "create", "cancel", "save", "destroy".
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.ListView = function() {};

kendo.ui.ListView.prototype = {
    add: function() {
        /// <summary>
        ///     Inserts empty item as first item on the current view and prepare it for editing.
        /// </summary>
    },

    cancel: function() {
        /// <summary>
        ///     Cancels changes in currently edited item.
        /// </summary>
    },

    clearSelection: function() {
        /// <summary>
        ///     Clears ListView selected items and triggers change event.
        /// </summary>
    },

    edit: function(item) {
        /// <summary>
        ///     Edit specified ListView item. Triggers edit event.
        /// </summary>
        /// <param name="item" type="Object">jQuery object containing the item to be edited.</param>
    },

    refresh: function() {
        /// <summary>
        ///     Reloads the data and repaints the list view.
        /// </summary>
    },

    remove: function(item) {
        /// <summary>
        ///     Removes specified ListView item. Triggers remove event and if not prevented calls DataSource sync method.
        /// </summary>
        /// <param name="item" type="Object">jQuery object containing the item to be removed.</param>
    },

    save: function() {
        /// <summary>
        ///     Saves edited ListView item. If validation succeeds will call DataSource sync method.
        /// </summary>
    },

    select: function(items) {
        /// <summary>
        ///     Selects the specified ListView item. If called without arguments - returns the selected items.
        /// </summary>
        /// <param name="items" type="Selector | Array">Items to select.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoListView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.ListView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.ListView">The kendo.ui.ListView instance (if present).</returns>
};

$.fn.kendoListView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.ListView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Indicates whether the list view will call read on the DataSource initially.
    ///     &#10;
    ///     &#10;dataSource — kendo.data.DataSource | Object undefined
    ///     &#10;Instance of DataSource or Object with DataSource configuration.
    ///     &#10;
    ///     &#10;editTemplate — Function undefined
    ///     &#10;Specifies ListView item template in edit mode.
    ///     &#10;
    ///     &#10;navigatable — Boolean (default: false)
    ///     &#10;Indicates whether keyboard navigation is enabled/disabled.
    ///     &#10;
    ///     &#10;selectable — String (default: false)
    ///     &#10;Indicates whether selection is enabled/disabled. Possible values:
    ///     &#10;
    ///     &#10;template — Function undefined
    ///     &#10;Specifies ListView item template.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Menu = function() {};

kendo.ui.Menu.prototype = {
    append: function(item, referenceItem) {
        /// <summary>
        ///     Appends an item to a **Menu** in the specified referenceItem's sub menu.
        /// </summary>
        /// <param name="item" type="Selector">Target item, specified as a JSON object. Can also handle an array of such objects.</param>
        /// <param name="referenceItem" type="Item">A reference item to append the new item in.</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    close: function(element) {
        /// <summary>
        ///     Closes a sub-menu of a specified item(s) in a **Menu**.
        /// </summary>
        /// <param name="element" type="Selector">Target item selector.</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    enable: function(element, enable) {
        /// <summary>
        ///     Enables or disables an item of a **Menu**. This can optionally be accomplished on
        ///     initialization by setting the **disabled="disabled"** on the desired menu item html element.
        /// </summary>
        /// <param name="element" type="Selector">Target element</param>
        /// <param name="enable" type="Boolean">Desired state</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    insertAfter: function(item, referenceItem) {
        /// <summary>
        ///     Inserts an item into a **Menu** after the specified referenceItem.
        /// </summary>
        /// <param name="item" type="Selector">Target item, specified as a JSON object. Can also handle an array of such objects.</param>
        /// <param name="referenceItem" type="Selector">A reference item to insert the new item after.</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    insertBefore: function(item, referenceItem) {
        /// <summary>
        ///     Inserts an item into a **Menu** before the specified referenceItem.
        /// </summary>
        /// <param name="item" type="Selector">Target item, specified as a JSON object. Can also handle an array of such objects.</param>
        /// <param name="referenceItem" type="Selector">A reference item to insert the new item before</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    open: function(element) {
        /// <summary>
        ///     Opens a sub-menu of a specified item(s) in a **Menu**.
        /// </summary>
        /// <param name="element" type="Selector">Target item selector.</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    remove: function(element) {
        /// <summary>
        ///     Removes a specified item(s) from a **Menu**.
        /// </summary>
        /// <param name="element" type="Selector">Target item selector.</param>
        /// <returns type="Menu">Returns the Menu object to support chaining.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoMenu = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Menu widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Menu">The kendo.ui.Menu instance (if present).</returns>
};

$.fn.kendoMenu = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Menu widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;A collection of **Animation** objects, used to change default animations. A value of false will disable all
    ///     animations in the widget.Available animations for the **Menu** are listed below.  Each animation has a reverse
    ///     options which is used for the **close** effect by default, but can be over-ridden
    ///     &#10;by setting the **close** animation.  Each animation also has a direction which can be set off the animation
    ///     (i.e. **slideIn:Down**).
    ///     &#10;
    ///     &#10;closeOnClick — Boolean (default: true)
    ///     &#10;Specifies that sub menus should close after item selection (provided they won't navigate).
    ///     &#10;
    ///     &#10;direction — String (default: "default")
    ///     &#10;Specifies Menu opening direction. Can be "top", "bottom", "left", "right".
    ///     &#10;You can also specify different direction for root and sub menu items, separating them with space. The example
    ///     below will initialize the root menu to open upwards and
    ///     &#10;its sub menus to the left.
    ///     &#10;
    ///     &#10;hoverDelay — Number (default: 100)
    ///     &#10;Specifies the delay in ms before the menu is opened/closed - used to avoid accidental closure on leaving.
    ///     &#10;
    ///     &#10;openOnClick — Boolean (default: false)
    ///     &#10;Specifies that the root sub menus will be opened on item click.
    ///     &#10;
    ///     &#10;orientation — String (default: "horizontal")
    ///     &#10;Root menu orientation. Could be horizontal or vertical.
    ///     &#10;
    ///     &#10;popupCollision — String undefined
    ///     &#10;Specifies how Menu should adjust to screen boundaries. By default the strategy is **"fit"** for a sub menu
    ///     with a horizontal parent,
    ///     &#10;meaning it will move to fit in screen boundaries in all directions, and **"fit flip"** for a sub menu with
    ///     vertical parent, meaning it will fit vertically and flip over
    ///     &#10;its parent horizontally. You can also switch off the screen boundary detection completely if you set the
    ///     **popupCollision** to false.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.NumericTextBox = function() {};

kendo.ui.NumericTextBox.prototype = {
    enable: function(enable) {
        /// <summary>
        ///     Enable/Disable the numerictextbox widget.
        /// </summary>
        /// <param name="enable" type="Boolean">The argument, which defines whether to enable/disable tha numerictextbox.</param>
    },

    focus: function() {
        /// <summary>
        ///     Focuses the numerictextbox widget.
        /// </summary>
    },

    max: function(value) {
        /// <summary>
        ///     Gets/Sets the max value of the NumericTextBox.
        /// </summary>
        /// <param name="value" type="Number | String">The max value to set.</param>
        /// <returns type="Number">The max value of the NumericTextBox.</returns>
    },

    min: function(value) {
        /// <summary>
        ///     Gets/Sets the min value of the NumericTextBox.
        /// </summary>
        /// <param name="value" type="Number | String">The min value to set.</param>
        /// <returns type="Number">The min value of the NumericTextBox.</returns>
    },

    step: function(value) {
        /// <summary>
        ///     Gets/Sets the step value of the NumericTextBox.
        /// </summary>
        /// <param name="value" type="Number | String">The step value to set.</param>
        /// <returns type="Number">The step value of the NumericTextBox.</returns>
    },

    value: function(value) {
        /// <summary>
        ///     Gets/Sets the value of the numerictextbox.
        /// </summary>
        /// <param name="value" type="Number | String">The value to set.</param>
        /// <returns type="Number">The value of the numerictextbox.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoNumericTextBox = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.NumericTextBox widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.NumericTextBox">The kendo.ui.NumericTextBox instance (if present).</returns>
};

$.fn.kendoNumericTextBox = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.NumericTextBox widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;culture — String (default: en-US)
    ///     &#10;Specifies the culture info used by the NumericTextBox widget.
    ///     &#10;
    ///     &#10;decimals — Number (default: null)
    ///     &#10;Specifies the number precision. If not set precision defined by current culture is used.
    ///     &#10;
    ///     &#10;downArrowText — String (default: Decrease value)
    ///     &#10;Specifies the text of the tooltip on the down arrow.
    ///     &#10;
    ///     &#10;format — String (default: n)
    ///     &#10;Specifies the format of the number. Any valid number format is allowed.
    ///     &#10;
    ///     &#10;max — Number (default: null)
    ///     &#10;Specifies the largest value the user can enter.
    ///     &#10;
    ///     &#10;min — Number (default: null)
    ///     &#10;Specifies the smallest value the user can enter.
    ///     &#10;
    ///     &#10;placeholder — String (default: "")
    ///     &#10;Specifies the text displayed when the input is empty.
    ///     &#10;
    ///     &#10;spinners — Boolean (default: true)
    ///     &#10;Specifies whether the up/down spin buttons should be rendered
    ///     &#10;
    ///     &#10;step — Number (default: 1)
    ///     &#10;Specifies the increment/decrement step.
    ///     &#10;
    ///     &#10;upArrowText — String (default: Increase value)
    ///     &#10;Specifies the text of the tooltip on the up arrow.
    ///     &#10;
    ///     &#10;value — Number (default: null)
    ///     &#10;Specifies the value of the NumericTextBox widget.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Pager = function() {};

kendo.ui.Pager.prototype = {
    totalPages: function() {
        /// <summary>
        ///     Returns the number of pages.
        /// </summary>
    },

    pageSize: function() {
        /// <summary>
        ///     Returns the page size - maximum number of items allowed on one page.
        /// </summary>
    },

    page: function() {
        /// <summary>
        ///     Set the specified page as a current page. If called without arguments - returns the current page.
        /// </summary>
    },

    refresh: function() {
        /// <summary>
        ///     Updates all values of pager elements so that these values fit the values of DataSource. This method is automaticaly
        ///     called after DataSource change event is fired.
        /// </summary>
    },

    destroy: function() {
        /// <summary>
        ///     Unbinds all callbacks created within pager initialization. This method doesn't remove pager element from DOM.
        /// </summary>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoPager = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Pager widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Pager">The kendo.ui.Pager instance (if present).</returns>
};

$.fn.kendoPager = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Pager widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;autoBind — Boolean (default: true)
    ///     &#10;Indicates whether the pager refresh method will be called within its initialization.
    ///     &#10;
    ///     &#10;buttonCount — Number (default: 10)
    ///     &#10;Defines the number of buttons displayed in the numeric pager.
    ///     &#10;
    ///     &#10;dataSource — kendo.data.DataSource undefined
    ///     &#10;Instance of kendo DataSource. See the
    ///     [**kendo.data.DataSource**](http://docs.kendoui.com/api/framework/datasource).This option is mandatory because the
    ///     Pager is tightly connected with DataSource. The pager is UI widget for managing paging over the DataSource. The
    ///     Pager gets values like page size or total count of items from DataSource.
    ///     &#10;
    ///     &#10;selectTemplate — String undefined
    ///     &#10;The template for selectbox with predefined page sizes.
    ///     &#10;
    ///     &#10;linkTemplate — String undefined
    ///     &#10;The template for page number links.
    ///     &#10;
    ///     &#10;info — Boolean (default: true)
    ///     &#10;Defines if a label showing current paging information will be displayed.
    ///     &#10;
    ///     &#10;input — Boolean (default: false)
    ///     &#10;Defines if an input element which allows the user to navigate to given page will be displayed.
    ///     &#10;
    ///     &#10;numeric — Boolean (default: true)
    ///     &#10;Defines if numeric portion of the pager will be shown.
    ///     &#10;
    ///     &#10;pageSizes — Boolean | Array (default: false | [5,10,20])
    ///     &#10;Displays a list with predefined page sizes. An array of values to be displayed can be provided. If pageSize
    ///     option is provided for DataSource then this pageSize value will be automaticaly selected in created selectbox.
    ///     &#10;
    ///     &#10;previousNext — Boolean (default: true)
    ///     &#10;Defines if buttons for navigating to the first, last, previous and next pages will be shown.
    ///     &#10;
    ///     &#10;refresh — Boolean (default: false)
    ///     &#10;Defines if a refresh button will be displayed. Click on that button will call DataSource read() method to get
    ///     actual data.
    ///     &#10;
    ///     &#10;messages — Object undefined
    ///     &#10;Defines texts shown within the pager.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.PanelBar = function() {};

kendo.ui.PanelBar.prototype = {
    append: function(item, referenceItem) {
        /// <summary>
        ///     Appends an item to the PanelBar.
        /// </summary>
        /// <param name="item" type="Selector">
        ///     Target item, specified as the JSON representation of an object. You can pass item
        ///     text, content or contentUrl here. Can handle an HTML string or array of such strings or JSON.
        /// </param>
        /// <param name="referenceItem" type="Item">A reference item to append the new item in</param>
        /// <returns type="PanelBar">Returns the PanelBar object to support chaining.</returns>
    },

    collapse: function(element, useAnimation) {
        /// <summary>
        ///     Collapses the specified item(s) of a **PanelBar**.
        /// </summary>
        /// <param name="element" type="Selector">
        ///     The **PanelBar** item(s) to be collapsed, expressed as a string containing a
        ///     selector expression or represented by a [jQuery selector](http://api.jquery.com/category/selectors/).
        /// </param>
        /// <param name="useAnimation" type="Boolean">
        ///     _optional, default: _Temporarily enables (**true**) or disables (**false**)
        ///     any visual animation(s) when collapsing items.
        /// </param>
        /// <returns type="PanelBar">Returns the PanelBar object to support chaining.</returns>
    },

    enable: function(element, enable) {
        /// <summary>
        ///     Enables (**true**) or disables (**false**) the specified item(s) of the
        ///     **PanelBar**.
        /// </summary>
        /// <param name="element" type="String | Selector">
        ///     The **PanelBar** item(s) to be enabled (**true**) or disabled
        ///     (**false**), expressed as a string containing a selector expression or represented by a [jQuery
        ///     selector](http://api.jquery.com/category/selectors/).
        /// </param>
        /// <param name="enable" type="Boolean">
        ///     The desired state - enabled (**true**) or disabled (**false**) - of the target
        ///     element(s).
        /// </param>
    },

    expand: function(element, useAnimation) {
        /// <summary>
        ///     Expands the specified item(s) of a **PanelBar**.
        /// </summary>
        /// <param name="element" type="Selector">The **PanelBar** item(s) to be expanded, expressed as a selector.</param>
        /// <param name="useAnimation" type="Boolean">
        ///     _optional, default: _Temporariliy enables (**true**) or disables (**false**)
        ///     any visual animation(s) when expanding items.
        /// </param>
        /// <returns type="PanelBar">Returns the PanelBar object to support chaining.</returns>
    },

    insertAfter: function(item, referenceItem) {
        /// <summary>
        ///     Inserts a PanelBar item after the specified referenceItem
        /// </summary>
        /// <param name="item" type="Selector">
        ///     Target item, specified as a JSON object. You can pass item text, content or
        ///     contentUrl here. Can handle an HTML string or array of such strings or JSON.
        /// </param>
        /// <param name="referenceItem" type="Item">A reference item to insert the new item after</param>
    },

    insertBefore: function(item, referenceItem) {
        /// <summary>
        ///     Inserts a PanelBar item before the specified referenceItem
        /// </summary>
        /// <param name="item" type="Selector">
        ///     Target item, specified as a JSON object. You can pass item text, content or
        ///     contentUrl here. Can handle an TML string or array of such strings or JSON.
        /// </param>
        /// <param name="referenceItem" type="Item">A reference item to insert the new item before.</param>
        /// <returns type="PanelBar">Returns the PanelBar object to support chaining.</returns>
    },

    reload: function(element) {
        /// <summary>
        ///     Reloads the content of a **PanelBar** from an AJAX request.
        /// </summary>
        /// <param name="element" type="Selector">Target element</param>
    },

    remove: function(element) {
        /// <summary>
        ///     Removes the specified PanelBar item(s).
        /// </summary>
        /// <param name="element" type="Selector">Target item selector.</param>
    },

    select: function(element) {
        /// <summary>
        ///     Selects the specified item of the **PanelBar**. If this method is invoked without arguments, it
        ///     returns the currently selected item.
        /// </summary>
        /// <param name="element" type="String | Selector">
        ///     The **PanelBar** item to be selected, expressed as a string containing a
        ///     selector expression or represented by a [jQuery selector](http://api.jquery.com/category/selectors/).
        /// </param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoPanelBar = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.PanelBar widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.PanelBar">The kendo.ui.PanelBar instance (if present).</returns>
};

$.fn.kendoPanelBar = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.PanelBar widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;A collection of visual animations used when **PanelBar** items are opened or closed through
    ///     &#10;user interactions. Setting this option to **false** will disable all animations.
    ///     &#10;
    ///     &#10;expandMode — String (default: "multiple")
    ///     &#10;Specifies how the **PanelBar** items are displayed when opened and closed. The following values
    ///     &#10;are available:
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.RangeSlider = function() {};

kendo.ui.RangeSlider.prototype = {
    destroy: function() {
        /// <summary>
        ///     Prepares the **RangeSlider** for safe removal from the DOM.Detaches event handlers and removes data entries in
        ///     order to avoid memory leaks.
        /// </summary>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enable/Disable the **RangeSlider** widget.
        /// </summary>
        /// <param name="enable" type="Boolean">The argument, which defines whether to enable/disable the **RangeSlider**.</param>
    },

    value: function(value) {
        /// <summary>
        ///     The value method gets or sets the start and end values of the **RangeSlider**. It
        ///     accepts an array as parameter, and returns an object array with the start and end
        ///     selection values.
        /// </summary>
        /// <param name="value" type=""></param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoRangeSlider = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.RangeSlider widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.RangeSlider">The kendo.ui.RangeSlider instance (if present).</returns>
};

$.fn.kendoRangeSlider = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.RangeSlider widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;largeStep — Number (default: 5)
    ///     &#10;The delta with which the value will change when the user presses the Page Up or Page Down key (the drag
    ///     &#10;handle must be focused). Note: The allied largeStep will also set large tick for every large step.
    ///     &#10;
    ///     &#10;max — Number (default: 10)
    ///     &#10;The maximum value of the **RangeSlider**.
    ///     &#10;
    ///     &#10;min — Number (default: 0)
    ///     &#10;The minimum value of the **RangeSlider**.
    ///     &#10;
    ///     &#10;orientation — String (default: "horizontal")
    ///     &#10;F
    ///     &#10;The orientation of a **RangeSlider**; **"horizontal"** or
    ///     &#10;**"vertical"**.
    ///     &#10;
    ///     &#10;selectionEnd — Number undefined
    ///     &#10;The selection end value of the **RangeSlider**.
    ///     &#10;
    ///     &#10;selectionStart — Number undefined
    ///     &#10;The selection start value of the **RangeSlider**.
    ///     &#10;
    ///     &#10;smallStep — Number (default: 1)
    ///     &#10;The small step value of the **RangeSlider**. The underlying value will be changed when the end
    ///     &#10;user (1) clicks on the increase or decrease buttons of the **RangeSlider**, (2) presses the
    ///     &#10;arrow keys (the drag handle must be focused), or (3) drags the drag handle.
    ///     &#10;
    ///     &#10;tickPlacement — String (default: "both")
    ///     &#10;Denotes the location of the tick marks in the **RangeSlider**. The available options are:
    ///     &#10;
    ///     &#10;tooltip — Object undefined
    ///     &#10;Configuration of the **RangeSlider** tooltip.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Slider = function() {};

kendo.ui.Slider.prototype = {
    destroy: function() {
        /// <summary>
        ///     Prepares the **Slider** for safe removal from the DOM.Detaches event handlers and removes data entries in order to
        ///     avoid memory leaks.
        /// </summary>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enable/Disable the **Slider** widget.
        /// </summary>
        /// <param name="enable" type="Boolean">The argument, which defines whether to enable/disable the **Slider**.</param>
    },

    value: function(value) {
        /// <summary>
        ///     Gets or sets the value of a **Slider**. It accepts a string or number as parameters and returns
        ///     a number representing the underlying value.
        /// </summary>
        /// <param name="value" type="String">_optional, default: _The value to be set for a Slider.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoSlider = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Slider widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Slider">The kendo.ui.Slider instance (if present).</returns>
};

$.fn.kendoSlider = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Slider widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;decreaseButtonTitle — String (default: "Decrease")
    ///     &#10;The title of the decrease button of the **Slider**.
    ///     &#10;
    ///     &#10;increaseButtonTitle — String (default: "Increase")
    ///     &#10;The title of the increase button of the **Slider**.
    ///     &#10;
    ///     &#10;largeStep — Number (default: 5)
    ///     &#10;The delta with which the value will change when the user presses the Page Up or Page Down key (the drag
    ///     &#10;handle must be focused). Note: The allied largeStep will also set large tick for every large step.
    ///     &#10;
    ///     &#10;max — Number (default: 10)
    ///     &#10;The maximum value of the **Slider**.
    ///     &#10;
    ///     &#10;min — Number (default: 0)
    ///     &#10;The minimum value of the **Slider**.
    ///     &#10;
    ///     &#10;orientation — String (default: "horizontal")
    ///     &#10;The orientation of a **Slider**: **"horizontal"** or **"vertical"**.
    ///     &#10;
    ///     &#10;showButtons — Boolean (default: true)
    ///     &#10;Can be used to show (**true**) or hide (**false**) the
    ///     &#10;increase and decrease buttons of a **Slider**.
    ///     &#10;
    ///     &#10;smallStep — Number (default: 1)
    ///     &#10;The small step value of the **Slider**. The underlying value will be changed when the end user
    ///     &#10;(1) clicks on the increase or decrease buttons of the **Slider**, (2) presses the arrow keys
    ///     &#10;(the drag handle must be focused), or (3) drags the drag handle.
    ///     &#10;
    ///     &#10;tickPlacement — String (default: "both")
    ///     &#10;Denotes the location of the tick marks in the **Slider**. The available options are:
    ///     &#10;
    ///     &#10;tooltip — Object undefined
    ///     &#10;Configuration of the **Slider** tooltip.
    ///     &#10;
    ///     &#10;value — Number undefined
    ///     &#10;The underlying value of the **Slider**.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Splitter = function() {};

kendo.ui.Splitter.prototype = {
    ajaxRequest: function(pane, url, data) {
        /// <summary>
        ///     Loads the content of a pane from a local or remote URL.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The targetted pane whose content is to be loaded via a URL.</param>
        /// <param name="url" type="String">A local or remote URL from which the content of the pane is to be loaded.</param>
        /// <param name="data" type="Object | String">Any data that is necessary to be sent to the server.</param>
    },

    collapse: function(pane) {
        /// <summary>
        ///     Collapses a specified pane. Invoking this method will force the **Splitter** to redraw and it
        ///     will trigger layoutChange and resize events. Note: Invoking the method will not trigger a collapse event.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane to be collapsed.</param>
    },

    expand: function(pane) {
        /// <summary>
        ///     Expands a specified pane. Invoking this method will force the **Splitter** to redraw and it
        ///     will trigger layoutChange and resize events. Note: Invoking the method will not trigger an expand event.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane to be expanded.</param>
    },

    max: function(pane, value) {
        /// <summary>
        ///     Sets the maximum size of a pane. Setting this value will not cause the **Splitter** to
        ///     redraw, nor will it trigger any events.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane being targetted for a new minimum size configuration value.</param>
        /// <param name="value" type="String">
        ///     The maximum size value of the pane defined as pixels (i.e. "200px") or as a
        ///     percentage (i.e. "50%").
        /// </param>
    },

    min: function(pane, value) {
        /// <summary>
        ///     Sets the minimum size of a pane. Setting this value will not cause the **Splitter** to
        ///     redraw, nor will it trigger any events.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane being targetted for a new minimum size configuration value.</param>
        /// <param name="value" type="String">
        ///     The minimum size value of the pane defined as pixels (i.e. "200px") or as a
        ///     percentage (i.e. "50%").
        /// </param>
    },

    size: function(pane, value) {
        /// <summary>
        ///     Set the size of the pane. Setting this value will cause the **Splitter** to redraw and it will
        ///     trigger layoutChange and resize events.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane to be resized.</param>
        /// <param name="value" type="String">
        ///     The new size of the pane defined as pixels (i.e. "200px") or as a percentage (i.e.
        ///     "50%"). Note: This value must not exceed **panes.max** or be less then **panes.min**.
        /// </param>
    },

    toggle: function(pane, expand) {
        /// <summary>
        ///     Toggles the state of a specified pane (i.e. collapsed or expanded). Invoking this method will force the
        ///     **Splitter** to redraw and it will trigger layoutChange and resize events. Note: Invoking the
        ///     method will not trigger collapse or expand events.
        /// </summary>
        /// <param name="pane" type="Selector | DOM Element">The pane to be collapsed.</param>
        /// <param name="expand" type="Boolean">
        ///     (Optional) Represents the desired state of the specified pane; to be expanded
        ///     (**true**) or collapsed (**false**). If undefined, toggle() will collapse the pane if it is expanded or will expand
        ///     the pane if it is collapsed.
        /// </param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoSplitter = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Splitter widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Splitter">The kendo.ui.Splitter instance (if present).</returns>
};

$.fn.kendoSplitter = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Splitter widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;orientation — String (default: horizontal)
    ///     &#10;Specifies the orientation of the **Splitter**.
    ///     &#10;
    ///     &#10;panes — Array undefined
    ///     &#10;An array of pane definitions.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.TabStrip = function() {};

kendo.ui.TabStrip.prototype = {
    activateTab: function(item) {
        /// <summary>
        ///     Activates a tab specified as a selector. Note: Invoking this method will not trigger any events.
        /// </summary>
        /// <param name="item" type="Selector">The target tab, specified as a selector, to be activated.</param>
        /// <returns type="Boolean">Returns <strong>true</strong> if successful; otherwise, <strong>false</strong>.</returns>
    },

    append: function(tab) {
        /// <summary>
        ///     Appends a tab to the collection of tabs in a **TabStrip**.
        /// </summary>
        /// <param name="tab" type="Selector">
        ///     Target tab, specified as a JSON object. You can pass tab text, content or contentUrl
        ///     here. Can handle an HTML string or array of such strings or JSON.
        /// </param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    contentElement: function(itemIndex) {
        /// <summary>
        ///     Obtains the DOM element representing a tab by its index in the **TabStrip**.
        /// </summary>
        /// <param name="itemIndex" type="int">The index of the tab in the TabStrip.</param>
        /// <returns type="HTMLElement">The DOM element representing a tab by its index in the <strong>TabStrip</strong>.</returns>
    },

    deactivateTab: function(item) {
        /// <summary>
        ///     Deactivates a tab specified as a selector. Note: Invoking this method will not trigger any events.
        /// </summary>
        /// <param name="item" type="Selector">The target tab, specified as a selector, to be deactivated.</param>
    },

    disable: function(element) {
        /// <summary>
        ///     Disables a tab(s) of a **TabStrip**.
        /// </summary>
        /// <param name="element" type="Selector">The target tab(s), specified as a selector, to be disabled.</param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    enable: function(element, enable) {
        /// <summary>
        ///     Disables (**false**) or enables (**true**) a tab(s) of a **TabStrip**.
        /// </summary>
        /// <param name="element" type="Selector">
        ///     The target tab(s), specified as a selector, to be enabled (**true**) or disabled
        ///     (**false**).
        /// </param>
        /// <param name="enable" type="Boolean">
        ///     Desired state of the tab(s) specified by the selector; enabled (**true**) or
        ///     disabled (**false**).
        /// </param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    insertAfter: function(item, referenceTab) {
        /// <summary>
        ///     Inserts a newly-created tab after a specified tab.
        /// </summary>
        /// <param name="item" type="Selector">
        ///     Target tab, specified as a JSON object. You can pass tab text, content or contentUrl
        ///     here. Can handle an HTML string or array of such strings or JSON.
        /// </param>
        /// <param name="referenceTab" type="Item">A reference tab to insert the new item after.</param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    insertBefore: function(item, referenceTab) {
        /// <summary>
        ///     Inserts a newly-created tab before a specified tab.
        /// </summary>
        /// <param name="item" type="Selector">
        ///     Target tab, specified as a JSON object. You can pass tab text, content or contentUrl
        ///     here. Can handle an HTML string or array of such strings or JSON.
        /// </param>
        /// <param name="referenceTab" type="Item">A reference tab to insert the new item before</param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    reload: function(element) {
        /// <summary>
        ///     Reloads TabStrip tab(s) via AJAX.
        /// </summary>
        /// <param name="element" type="Selector">The target tab(s), specified as a selector, to be reloaded via AJAX.</param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    remove: function(element) {
        /// <summary>
        ///     Removes a specified tab from a TabStrip.
        /// </summary>
        /// <param name="element" type="Selector">The target tab(s), specified as a selector, to be removed.</param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    select: function(element) {
        /// <summary>
        ///     Selects the specified tab(s) within a **TabStrip**. If called without arguments, it returns the
        ///     currently selected tab.
        /// </summary>
        /// <param name="element" type="Selector/Index">
        ///     or index The target tab(s), specified as a selector or index in the tab
        ///     group.
        /// </param>
        /// <returns type="TabStrip">Returns the TabStrip object to support chaining.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoTabStrip = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.TabStrip widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.TabStrip">The kendo.ui.TabStrip instance (if present).</returns>
};

$.fn.kendoTabStrip = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.TabStrip widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;A collection of visual animations used when **TabStrip** tab are selected through
    ///     &#10;user interactions. Setting this option to **false** will disable all animations.
    ///     &#10;
    ///     &#10;collapsible — Boolean (default: false)
    ///     &#10;Specifies whether the TabStrip should be able to collapse completely when clicking an expanded tab.
    ///     &#10;
    ///     &#10;dataContentField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the text content of
    ///     &#10;the tab content element.
    ///     &#10;
    ///     &#10;dataContentUrlField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the URL for
    ///     &#10;the ajax loaded tab content.
    ///     &#10;
    ///     &#10;dataImageUrlField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the image URL of
    ///     &#10;the tab.
    ///     &#10;
    ///     &#10;dataSpriteCssClass — String (default: "")
    ///     &#10;Sets the field of the data item that provides the CSS class of
    ///     &#10;the tab.
    ///     &#10;
    ///     &#10;dataTextField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the text name of the tab.
    ///     &#10;
    ///     &#10;dataUrlField — String (default: "")
    ///     &#10;Sets the field of the data item that provides the link URL for the
    ///     &#10;tab.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.TimePicker = function() {};

kendo.ui.TimePicker.prototype = {
    close: function() {
        /// <summary>
        ///     Closes the drop-down list of a TimePicker.
        /// </summary>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enables or disables a TimePicker.
        /// </summary>
        /// <param name="enable" type="Boolean">Enables (**true** or undefined) or disables (**false**) a TimePicker.</param>
    },

    max: function(value) {
        /// <summary>
        ///     Gets or sets the maximum value of the TimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The maximum time value to set for a TimePicker, expressed as a Date object or as
        ///     a string.
        /// </param>
        /// <returns type="Date">The maximum time value of a TimePicker.</returns>
    },

    min: function(value) {
        /// <summary>
        ///     Gets or sets the minimum value of the TimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The minimum time value to set for a TimePicker, expressed as a Date object or as
        ///     a string.
        /// </param>
        /// <returns type="Date">The minimum time value of a TimePicker.</returns>
    },

    open: function() {
        /// <summary>
        ///     Opens the drop-down list of a TimePicker.
        /// </summary>
    },

    value: function(value) {
        /// <summary>
        ///     Gets or sets the value of the TimePicker.
        /// </summary>
        /// <param name="value" type="Date|String">
        ///     The time value to set for a TimePicker, expressed as a Date object or as a
        ///     string.
        /// </param>
        /// <returns type="Date">The time value of a TimePicker.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoTimePicker = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.TimePicker widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.TimePicker">The kendo.ui.TimePicker instance (if present).</returns>
};

$.fn.kendoTimePicker = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.TimePicker widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;Animations to be used for opening/closing the popup. Setting to false will turn of the animation.
    ///     &#10;
    ///     &#10;culture — String (default: en-US)
    ///     &#10;Specifies the culture info used by the widget.
    ///     &#10;
    ///     &#10;dates — Array undefined
    ///     &#10;Specifies a list of dates, which are shown in the time drop-down list. If not set, the DateTimePicker will
    ///     auto-generate the available times.
    ///     &#10;
    ///     &#10;format — String (default: h:mm tt)
    ///     &#10;Specifies the format, which is used to format the value of the TimePicker displayed in the input. The format
    ///     also will be used to parse the input.
    ///     &#10;
    ///     &#10;interval — Number (default: 30)
    ///     &#10;Specifies the interval, between values in the popup list, in minutes.
    ///     &#10;
    ///     &#10;max — Date (default: 00:00)
    ///     &#10;Specifies the end value in the popup list.
    ///     &#10;
    ///     &#10;min — Date (default: 00:00)
    ///     &#10;Specifies the start value in the popup list.
    ///     &#10;
    ///     &#10;parseFormats — Array undefined
    ///     &#10;Specifies the formats, which are used to parse the value set with the value method or by direct input. If not
    ///     set the value of the options.format will be used. Note that value of the format option is always used.
    ///     &#10;
    ///     &#10;value — Date (default: null)
    ///     &#10;Specifies the selected time.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.TreeView = function() {};

kendo.ui.TreeView.prototype = {
    append: function(nodeData, parentNode) {
        /// <summary>
        ///     Appends a node to a group of a TreeView. This method may also be used to reorder the nodes of a
        ///     TreeView.
        /// </summary>
        /// <param name="nodeData" type="String|Selector">
        ///     A JSON-formatted string or selector that specifies the node to be
        ///     appended.
        /// </param>
        /// <param name="parentNode" type="Node">
        ///     The node that will contain the newly appended node. If not specified, the new node
        ///     will be appended to the root group of the TreeView.
        /// </param>
    },

    collapse: function(nodes) {
        /// <summary>
        ///     Collapses nodes.
        /// </summary>
        /// <param name="nodes" type="Selector">The nodes that are to be collapsed.</param>
    },

    dataItem: function(node) {
        /// <summary>
        ///     Returns the model dataItem that corresponds to a TreeView node
        /// </summary>
        /// <param name="node" type="jQueryObject | DomElement | Selector">The element or selector that specifies a node.</param>
    },

    detach: function(node) {
        /// <summary>
        ///     Removes a node from a TreeView, but keeps its jQuery.data() objects.
        /// </summary>
        /// <param name="node" type="Selector">The node that is to be detached.</param>
        /// <returns type="jQuery">The node that has been detached.</returns>
    },

    enable: function(nodes, enable) {
        /// <summary>
        ///     Enables or disables nodes.
        /// </summary>
        /// <param name="nodes" type="Selector">The nodes that are to be enabled/disabled.</param>
        /// <param name="enable" type="Boolean">Whether the nodes should be enabled or disabled.</param>
    },

    expand: function(nodes) {
        /// <summary>
        ///     Expands nodes.
        /// </summary>
        /// <param name="nodes" type="Selector">The nodes that are to be expanded.</param>
    },

    findByText: function(text) {
        /// <summary>
        ///     Searches a TreeView for a node that has specific text.
        /// </summary>
        /// <param name="text" type="String">The text that is being searched for.</param>
        /// <returns type="jQuery">All nodes that have the text.</returns>
    },

    findByUid: function(text) {
        /// <summary>
        ///     Searches a TreeView for a node with the given unique identifier.
        ///     Applicable when the widget is bound to a [HierarchicalDataSource](/api/framework/hierarchicaldatasource).
        /// </summary>
        /// <param name="text" type="String">The text that is being searched for.</param>
        /// <returns type="jQueryObject">All nodes that have the text.</returns>
    },

    insertAfter: function(nodeData, referenceNode) {
        /// <summary>
        ///     Inserts a node after a specified node in a TreeView. This method may also be used to reorder the nodes of a
        ///     TreeView.
        /// </summary>
        /// <param name="nodeData" type="String | Selector">
        ///     A JSON-formatted string or selector that specifies the node to be
        ///     inserted.
        /// </param>
        /// <param name="referenceNode" type="Node">The node that will be preceed the newly-appended node.</param>
    },

    insertBefore: function(nodeData, referenceNode) {
        /// <summary>
        ///     Inserts a node before another node. This method may also be used to reorder the nodes of a
        ///     TreeView.
        /// </summary>
        /// <param name="nodeData" type="String | Selector">
        ///     A JSON-formatted string or selector that specifies the node to be
        ///     inserted.
        /// </param>
        /// <param name="referenceNode" type="Node">The node that follows the inserted node.</param>
    },

    remove: function(node) {
        /// <summary>
        ///     Removes a node from a TreeView.
        /// </summary>
        /// <param name="node" type="Selector">The node that is to be removed.</param>
    },

    select: function(node) {
        /// <summary>
        ///     Gets or sets the selected node of a TreeView.
        /// </summary>
        /// <param name="node" type="Selector">If provided, the node of a TreeView that should be selected.</param>
        /// <returns type="Node">The selected node of a TreeView.</returns>
    },

    text: function(node) {
        /// <summary>
        ///     Gets the text of a node in a TreeView.
        /// </summary>
        /// <param name="node" type="Selector">The node of which the text is being retrieved.</param>
        /// <returns type="String">The text of a node.</returns>
    },

    toggle: function(node) {
        /// <summary>
        ///     Toggles the node of a TreeView between its expanded and collapsed states.
        /// </summary>
        /// <param name="node" type="Selector">The node that should be toggled.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoTreeView = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.TreeView widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.TreeView">The kendo.ui.TreeView instance (if present).</returns>
};

$.fn.kendoTreeView = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.TreeView widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;A collection of visual animations used when items are expanded or collapsed through user interaction.
    ///     &#10;Setting this option to **false** will disable all animations.
    ///     &#10;
    ///     &#10;checkboxTemplate — String|Function undefined
    ///     &#10;Template for rendering of the treeview checkboxes.
    ///     &#10;
    ///     &#10;dataImageUrlField — String (default: null)
    ///     &#10;Sets the field of the data item that provides
    ///     &#10;the image URL of the treeview nodes.
    ///     &#10;
    ///     &#10;dataSource — Array undefined
    ///     &#10;The data that the **TreeView** will be bound to.
    ///     &#10;
    ///     &#10;dataSpriteCssClassField — String (default: null)
    ///     &#10;Sets the field of the data item that provides
    ///     &#10;the sprite CSS class of the treeview nodes.
    ///     &#10;
    ///     &#10;dataTextField — String (default: null)
    ///     &#10;Sets the field of the data item that provides
    ///     &#10;the text content of the treeview nodes.
    ///     &#10;
    ///     &#10;dataUrlField — String (default: null)
    ///     &#10;Sets the field of the data item that provides
    ///     &#10;the link URL of the treeview nodes.
    ///     &#10;
    ///     &#10;dragAndDrop — Boolean (default: false)
    ///     &#10;Disables (**false**) or enables (**true**) drag-and-drop on the nodes of a
    ///     &#10;**TreeView**.
    ///     &#10;
    ///     &#10;loadOnDemand — Boolean (default: true)
    ///     &#10;Indicates whether the child datasources should be fetched
    ///     &#10;lazily, when parent groups get expanded. Setting this to false causes all child dataSources to
    ///     &#10;be loaded at initialization time. Note: when initializing a TreeView from array (rather than from a
    ///     &#10;HierarchicalDataSource instance), the default value of this option is false.
    ///     &#10;
    ///     &#10;template — String|Function undefined
    ///     &#10;Template for rendering of the nodes of the treeview.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Upload = function() {};

kendo.ui.Upload.prototype = {
    disable: function() {
        /// <summary>
        ///     Disables the upload.
        /// </summary>
    },

    destroy: function() {
        /// <summary>
        ///     Prepares the Upload for safe removal from the DOM.Detaches event handlers and removes data entries in order to
        ///     avoid memory leaks.
        /// </summary>
    },

    enable: function(enable) {
        /// <summary>
        ///     Enables the upload.
        /// </summary>
        /// <param name="enable" type=""></param>
    },

    toggle: function(enable) {
        /// <summary>
        ///     Toggles the upload enabled state.
        /// </summary>
        /// <param name="enable" type="Boolean">(Optional) The new enabled state.</param>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoUpload = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Upload widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Upload">The kendo.ui.Upload instance (if present).</returns>
};

$.fn.kendoUpload = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Upload widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;async — Object undefined
    ///     &#10;Configures the ability to upload a file(s) in an asynchronous manner. Please refer to the
    ///     &#10;[async mode help topic](http://www.kendoui.com/documentation/ui-widgets/upload/modes.aspx#async)
    ///     &#10;for more details.
    ///     &#10;
    ///     &#10;enabled — Boolean (default: true)
    ///     &#10;Enables (**true**) or disables (**false**) an **Upload**. A disabled
    ///     &#10;**Upload** may be re-enabled via enable().
    ///     &#10;
    ///     &#10;localization — Object undefined
    ///     &#10;Sets the strings rendered by the Upload.
    ///     &#10;
    ///     &#10;multiple — Boolean (default: true)
    ///     &#10;Enables (**true**) or disables (**false**) the ability to select multiple files.
    ///     &#10;If **false**, users will be able to select only one file at a time. Note: This option does not
    ///     &#10;limit the total number of uploaded files in an asynchronous configuration.
    ///     &#10;
    ///     &#10;showFileList — Boolean (default: true)
    ///     &#10;Enables (**true**) or disables (**false**) the ability to display a file listing
    ///     &#10;for uploading a file(s). Disabling a file listing may be useful you wish to customize the UI; use the
    ///     &#10;client-side events to build your own UI.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Validator = function() {};

kendo.ui.Validator.prototype = {
    errors: function() {
        /// <summary>
        ///     Get the error messages if any.
        /// </summary>
        /// <returns type="Array">Messages for the failed validation rules.</returns>
    },

    validate: function() {
        /// <summary>
        ///     Validates the input element(s) against the declared validation rules.
        /// </summary>
        /// <returns type="Boolean` `true">if all validation rules passed successfully.</returns>
    },

    validateInput: function(input) {
        /// <summary>
        ///     Validates the input element against the declared validation rules.
        /// </summary>
        /// <param name="input" type="Element" domElement="true">Input element to be validated.</param>
        /// <returns type="Boolean` `true">if all validation rules passed successfully.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoValidator = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Validator widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Validator">The kendo.ui.Validator instance (if present).</returns>
};

$.fn.kendoValidator = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Validator widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;messages — Object undefined
    ///     &#10;Set of messages (either strings or functions) which will be shown when given validation rule fails.
    ///     &#10;By setting already existing key the appropriate built-in message will be overridden.
    ///     &#10;
    ///     &#10;rules — Object undefined
    ///     &#10;Set of custom validation rules. Those rules will extend the [built-in
    ///     ones](/getting-started/framework/validator/overview#default-validation-rules).
    ///     &#10;
    ///     &#10;validateOnBlur — Boolean undefined
    ///     &#10;Determines if validation will be triggered when element loses focus. Default value is true.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

kendo.ui.Window = function() {};

kendo.ui.Window.prototype = {
    center: function() {
        /// <summary>
        ///     Centers a **Window** within the viewport.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    close: function() {
        /// <summary>
        ///     Closes a Window.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    content: function(content) {
        /// <summary>
        ///     Gets or set the content of a **Window**.
        /// </summary>
        /// <param name="content" type="String">_optional, default: _The content of the Window.</param>
        /// <returns type="Window">
        ///     If content is provided, this method will return the (Kendo UI) Window object to support
        ///     chaining. Otherwise,
        /// </returns>
    },

    destroy: function() {
        /// <summary>
        ///     Destroys the window and its modal overlay, if necessary. Removes the Window HTML elements from the DOM.
        /// </summary>
    },

    maximize: function() {
        /// <summary>
        ///     Maximizes a Window to the entire viewing area of the user agent. Triggers the resize event.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    minimize: function() {
        /// <summary>
        ///     Maximizes a Window to its title bar.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    open: function() {
        /// <summary>
        ///     Opens a Window.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    refresh: function(options) {
        /// <summary>
        ///     Refreshes the content of a Window from a remote URL.
        /// </summary>
        /// <param name="options" type="Object|String">
        ///     Options for requesting data from the server. If omitted, the window uses the
        ///     `content` property that was supplied when the window was created. Any options specified here are passed to
        ///     jQuery.ajax().
        /// </param>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    restore: function() {
        /// <summary>
        ///     Restores a maximized or minimized Window to its previous state. Triggers the resize event.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    title: function(text) {
        /// <summary>
        ///     Gets or set the title of a **Window**.
        /// </summary>
        /// <param name="text" type="String">_optional, default: _The title of the Window.</param>
        /// <returns type="Window">
        ///     If a title is provided, this method will return the (Kendo UI) Window object to support
        ///     chaining. Otherwise,
        /// </returns>
    },

    toFront: function() {
        /// <summary>
        ///     Brings forward a Window to the top of the z-index.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    toggleMaximization: function() {
        /// <summary>
        ///     Toggles a Window between a maximized and restored state. Triggers the resize event.
        /// </summary>
        /// <returns type="Window">Returns the (Kendo UI) Window object to support chaining.</returns>
    },

    bind: function(event, callback) {
        /// <summary>
        ///     Binds to a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be executed when the event is triggered.</param>
    },

    unbind: function(event, callback) {
        /// <summary>
        ///     Unbinds a callback from a widget event.
        /// </summary>
        /// <param name="event" type="String">The event name</param>
        /// <param name="callback" type="Function">The callback to be removed.</param>
    }
};

$.fn.getKendoWindow = function() {
    /// <summary>
    ///     Returns a reference to the kendo.ui.Window widget, instantiated on the selector.
    /// </summary>
    /// <returns type="kendo.ui.Window">The kendo.ui.Window instance (if present).</returns>
};

$.fn.kendoWindow = function(options) {
    /// <summary>
    ///     Instantiates a kendo.ui.Window widget based the DOM elements that match the selector.
    ///     &#10;Accepts an object with the following configuration options:
    ///     &#10;
    ///     &#10;actions — Array (default: ["Close"])
    ///     &#10;The buttons for interacting with the window. Predefined array values are "Close", "Refresh", "Minimize",
    ///     &#10;and "Maximize".
    ///     &#10;
    ///     &#10;animation — Object undefined
    ///     &#10;A collection of {Animation} objects, used to change default animations. A value of **false**
    ///     &#10;will disable all animations in the widget.
    ///     &#10;
    ///     &#10;appendTo — Object (default: document.body)
    ///     &#10;The element that the Window will be appended to.
    ///     &#10;
    ///     &#10;content — Object|String undefined
    ///     &#10;Specifies a URL or request options that the window should load its content from. For remote URLs, a
    ///     &#10;container iframe element is automatically created.
    ///     &#10;
    ///     &#10;draggable — Boolean (default: true)
    ///     &#10;Enables (**true**) or disables (**false**) the ability for users to move/drag a
    ///     &#10;**Window**.
    ///     &#10;
    ///     &#10;iframe — Boolean undefined
    ///     &#10;Explicitly states whether content iframe should be created.
    ///     &#10;
    ///     &#10;maxHeight — Number (default: Infinity)
    ///     &#10;The maximum height (in pixels) that may be achieved by resizing the window.
    ///     &#10;
    ///     &#10;maxWidth — Number (default: Infinity)
    ///     &#10;The maximum width (in pixels) that may be achieved by resizing the window.
    ///     &#10;
    ///     &#10;minHeight — Number (default: 50)
    ///     &#10;The minimum height (in pixels) that may be achieved by resizing the window.
    ///     &#10;
    ///     &#10;minWidth — Number (default: 50)
    ///     &#10;The minimum width (in pixels) that may be achieved by resizing the window.
    ///     &#10;
    ///     &#10;modal — Boolean (default: false)
    ///     &#10;Specifies whether the window should show a modal overlay over the page.
    ///     &#10;
    ///     &#10;resizable — Boolean (default: true)
    ///     &#10;Enables (**true**) or disables (**false**) the ability for users to resize a
    ///     &#10;**Window**.
    ///     &#10;
    ///     &#10;title — String undefined
    ///     &#10;The text in the window title bar.
    ///     &#10;
    ///     &#10;visible — Boolean (default: true)
    ///     &#10;Specifies whether the window will be initially visible.
    ///     &#10;
    /// </summary>
    /// <param name="options" type="Object">
    ///     The widget configuration options
    /// </param>
};

// vim:ft=javascript