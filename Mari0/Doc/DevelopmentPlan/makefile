filename = DevelopmentPlan
pdf:ps
	ps2pdf ${filename}.ps
ps:dvi
	dvips -t letter ${filename}.dvi
dvi:    
	latex ${filename}
	latex ${filename}
	latex ${filename}
clean:	
	mv ${filename}.tex ${filename}
	rm ${filename}.*
	mv ${filename} ${filename}.tex
