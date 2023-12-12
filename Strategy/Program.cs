using Strategy;
// Client class
// What we have done is differed knowledge of the export service to the client.
// The client can now decide which export service to use.
// The Order Class does not have to know about the export service.
//
// var order = new Order("Order 1", "Customer 1", 100);
// order.ExportService = new CSVExportService();
// order.Export();
//
// order.ExportService = new JSONExportService();
// order.Export();
//
// order.ExportService = new XMLExportService();
// order.Export();

// using method parameter

var order = new Order("Order 1", "Customer 1", 100);
order.Export(new CSVExportService());
order.Export(new JSONExportService());
order.Export(new XMLExportService());

Console.ReadKey();