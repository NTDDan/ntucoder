import React from "react";
import { Flex, Button, Text, Select, Icon, useColorMode } from "@chakra-ui/react";
import { MdChevronLeft, MdChevronRight } from "react-icons/md";

export default function Pagination({
    currentPage,
    totalPages,
    pageSize,
    onPageChange,
    onPageSizeChange,
}) {
    const { colorMode } = useColorMode(); // Lấy trạng thái chế độ màu
    const textColor = colorMode === 'light' ? 'black' : 'white'; // Đổi màu text
    // Hàm tạo danh sách số trang cần hiển thị
    const createPageNumbers = () => {
        const pageNumbers = [];
        const maxPagesToShow = 3; // Giới hạn số trang hiển thị ở giữa
        let startPage, endPage;

        if (totalPages <= maxPagesToShow) {
            // Nếu tổng số trang ít hơn hoặc bằng số trang tối đa cần hiển thị
            startPage = 1;
            endPage = totalPages;
        } else {
            // Nếu tổng số trang nhiều hơn số trang tối đa
            if (currentPage <= Math.ceil(maxPagesToShow / 2)) {
                // Nếu trang hiện tại ở gần đầu
                startPage = 1;
                endPage = maxPagesToShow;
            } else if (currentPage + Math.floor(maxPagesToShow / 2) >= totalPages) {
                // Nếu trang hiện tại ở gần cuối
                startPage = totalPages - maxPagesToShow + 1;
                endPage = totalPages;
            } else {
                // Nếu trang hiện tại ở giữa
                startPage = currentPage - Math.floor(maxPagesToShow / 2);
                endPage = currentPage + Math.floor(maxPagesToShow / 2);
            }
        }

        for (let i = startPage; i <= endPage; i++) {
            pageNumbers.push(i);
        }

        return pageNumbers;
    };

    const pageNumbers = createPageNumbers();

    return (
        <Flex direction="row" align="center" mt={4} mr={4} justify="space-between">
            {/* Hiển thị lựa chọn số item trên mỗi trang */}
            <Flex mb={2} alignItems="center">
                <Text mr={2}>Số dòng hiển thị:</Text>
                <Select
                    value={pageSize}
                    onChange={(e) => onPageSizeChange(parseInt(e.target.value, 10))}
                    width="auto"
                    ml={4}
                    variant="outline"
                    colorScheme="blue"
                    sx={{
                        option: {
                            color: textColor, // Áp dụng màu từ textColor
                            bg: colorMode === 'dark' ? 'gray.700' : 'white', // Màu nền phù hợp với chế độ sáng/tối
                        },
                    }}
                >
                    <option value={1}>1 dòng</option>
                    <option value={5}>5 dòng</option>
                    <option value={10}>10 dòng</option>
                    <option value={15}>15 dòng</option>
                    <option value={20}>20 dòng</option>
                </Select>
            </Flex>

            {/* Hiển thị các nút phân trang */}
            <Flex alignItems="center">
                {/* Nút Previous */}
                <Button
                    onClick={() => onPageChange(currentPage - 1)}
                    isDisabled={currentPage === 1}
                    mr={2}
                    colorScheme="blue"
                    variant="outline"
                    p={0}
                    _hover={{ bg: "blue.500", border: "blue.500", textColor: "white" }}
                    _active={{ transform: "scale(0.90)" }}
                    size={"sm"}
                    borderRadius="xl"
                >
                    <Icon as={MdChevronLeft} w={5} h={5} ></Icon>
                </Button>

                {/* Hiển thị nút trang đầu nếu cần */}
                {pageNumbers[0] > 1 && (
                    <>
                        <Button
                            onClick={() => onPageChange(1)}
                            colorScheme="blue"
                            _hover={{ bg: "blue.100", border: "blue.100" }}
                            variant="outline"
                            size={"sm"}
                            borderRadius="xl"
                        >
                            1
                        </Button>
                        {pageNumbers[0] > 2 && <Text mx={1}>...</Text>}
                    </>
                )}

                {/* Hiển thị các số trang */}
                {pageNumbers.map((page) => (
                    <Button
                        key={page}
                        onClick={() => onPageChange(page)}
                        colorScheme="blue"
                        variant={page === currentPage ? "solid" : "outline"}
                        mx={1}
                        _hover={{ bg: "blue.100", border: "blue.100" }}
                        size={"sm"}
                        borderRadius="xl"
                    >
                        {page}
                    </Button>
                ))}

                {/* Hiển thị nút trang cuối nếu cần */}
                {pageNumbers[pageNumbers.length - 1] < totalPages && (
                    <>
                        {pageNumbers[pageNumbers.length - 1] < totalPages - 1 && (
                            <Text mx={1}>...</Text>
                        )}
                        <Button
                            onClick={() => onPageChange(totalPages)}
                            colorScheme="blue"
                            variant="outline"
                            _hover={{ bg: "blue.100", border: "blue.100" }}
                            size={"sm"}
                            borderRadius="xl"
                        >
                            {totalPages}
                        </Button>
                    </>
                )}

                {/* Nút Next */}
                <Button
                    onClick={() => onPageChange(currentPage + 1)}
                    isDisabled={currentPage === totalPages}
                    ml={2}
                    colorScheme="blue"
                    variant="outline"
                    _hover={{ bg: "blue.500", border: "blue.500", textColor: "white" }}
                    _active={{ transform: "scale(0.90)" }}
                    p={0}
                    size={"sm"}
                    borderRadius="xl"
                >
                    <Icon as={MdChevronRight} w={5} h={5} ></Icon>
                </Button>
            </Flex>
        </Flex>
    );
}
